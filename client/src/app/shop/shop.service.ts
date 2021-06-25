import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaginationParams } from '../shared/model/paginationParams';
import { IProduct } from '../shared/model/product';
import { IProductType } from '../shared/model/productType';
import { IResponse } from '../shared/model/response';
import { ShopParams } from '../shared/model/shopParams';

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

  // getProducts(): Observable<HttpResponse<IResponse<Array<IProduct>>>> {
  //   let params = new HttpParams();
    
  //   return this.http.get<IResponse<Array<IProduct>>>(this.baseUrl + 'products/all', { observe: 'response', params });
  
  // }

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

  // getProductsTemp(shopParams: ShopParams, pagination: Pagination): Observable<HttpResponse<IResponse<Array<IProduct>>>> {
  //   var url = this.baseUrl + "products/items?";

  //   let params = new HttpParams();

  //   if (shopParams.productTypeId !== '') {
  //     params = params.append('productTypeId', shopParams.productTypeId)
  //   }

  //   if (shopParams.keyword !== '') {
  //     params = params.append('keyword', shopParams.keyword)
  //   }

  //   params = params.append('orderBy', shopParams.sort);
  //   params = params.append('pageNumber', pagination.PageIndex.toString());
  //   params = params.append('pageSize', pagination.PageSize.toString());


  //   return this.http.get<IResponse<Array<IProduct>>>(url, { observe: 'response', params });
  // }
}
