import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaginationParams } from '../shared/models/paginationParams';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';
import { IResponse } from '../shared/models/response';
import { ShopParams } from '../shared/models/shopParams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseUrl = environment.apiUrl;
  products: IProduct[] = [];
  productTypeList: IProductType[] = [];
  private shopParams: ShopParams = new ShopParams();
  private paginationParams: PaginationParams = new PaginationParams();
  totalCount: number = 0;
  sortOptions = [
    { name: '價格', value: 'orignalPrice' },
    { name: '商品名稱', value: 'title' }
  ];

  constructor(private http: HttpClient) { }

  getProducts(): Observable<HttpResponse<IResponse<Array<IProduct>>>> {
    let params = new HttpParams();
    if (this.shopParams.productTypeId !== '') {
      params = params.append('productTypeId', this.shopParams.productTypeId)
    }
    if (this.shopParams.keyword !== '') {
      params = params.append('keyword', this.shopParams.keyword)
    }
    if (this.shopParams.sort !== '') {
      params = params.append('sort', this.shopParams.sort)
    }
    params = params.append('sort', this.shopParams.sort);
    params = params.append('pageIndex', this.paginationParams.PageIndex.toString());
    params = params.append('pageSize', this.paginationParams.PageSize.toString());
    return this.http.get<IResponse<Array<IProduct>>>(this.baseUrl + 'products', { observe: 'response', params });
  }

  getProduct(id: string) {
    return this.http.get<IResponse<IProduct>>(this.baseUrl + 'products/' + id);
  }

  getProductTypes() {
    return this.http.get<IResponse<Array<IProductType>>>(this.baseUrl + 'products/productTypes');
  }

  getShopParams() {
    return this.shopParams;
  }

  setShopParams(params: ShopParams) {
    this.shopParams = params;
  }

  getPaginationParams(){
    return this.paginationParams;
  }

  setPaginationParams(params: PaginationParams) {
    this.paginationParams = params;
  }

  createProduct(newProduct: IProduct) {
    return this.http.post<IResponse<IProduct>>(this.baseUrl + 'products', newProduct);
  }

  removeProduct(productId: string) {
    return this.http.delete(this.baseUrl + 'products/' + productId);
  }

  updateProduct(productId, product: IProduct) {
    return this.http.put(this.baseUrl + 'products/', product);
  }
}
