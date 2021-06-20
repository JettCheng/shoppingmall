import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { PaginationParams } from '../shared/model/paginationParams';
import { IProduct } from '../shared/model/product';
import { IProductType } from '../shared/model/productType';
import { ShopParams } from '../shared/model/shopParams';
import { ShopService } from './shop.service';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  @ViewChild('search', { static: false }) searchTerm!: ElementRef;

  error: string;
  products: IProduct[] = [];
  productTypeList: IProductType[] = [];
  shopParams: ShopParams = new ShopParams();
  paginationParams: PaginationParams = new PaginationParams();
  sortOptions = [
    {name: '名稱', value: 'titie'},
    {name: '價格由低到高', value: 'originalPrice asc'},
    {name: '價格由高到低', value: 'originalPrice desc'},
  ];

  constructor(private shopService: ShopService) { }

  ngOnInit(): void {
    this.getProductTypes();
    this.getProducts();
  }

  onProductTypeSelected(id: string) {
    const shopParams = this.shopService.getShopParams();
    const PaginationParams = this.shopService.getPaginationParams();
    shopParams.productTypeId = id;
    PaginationParams.PageIndex = 1;
    this.shopService.setShopParams(shopParams);
    this.shopService.setPaginationParams(PaginationParams);
    this.getProducts();
  }

  onSearch() {
    const shopParams = this.shopService.getShopParams();
    const paginationParams = this.shopService.getPaginationParams();
    shopParams.keyword = this.searchTerm.nativeElement.value;
    paginationParams.PageIndex = 1
    this.shopService.setShopParams(shopParams);
    this.shopService.setPaginationParams(paginationParams);
    this.getProducts();
  }

  onReset() {
    this.searchTerm.nativeElement.value = '';
    this.shopParams = new ShopParams();
    this.shopService.setShopParams(this.shopParams);
    this.getProducts();
  }

  onPageChanged(pageIndex: any) {
    const shopParams = this.shopService.getShopParams();
    const paginationParams = this.shopService.getPaginationParams();
    if (paginationParams.PageIndex!==pageIndex) {
      paginationParams.PageIndex = pageIndex;
      this.shopService.setPaginationParams(paginationParams);
      this.getProducts();
    }
  }
  onAllProductClick() {    
    const shopParams = new ShopParams();
    const paginationParams = new PaginationParams();
    this.shopService.setShopParams(shopParams);
    this.shopService.setPaginationParams(paginationParams);
    this.getProducts();
  }

  onSortSelected(sort: string) {
    const params = this.shopService.getShopParams();
    params.sort = sort;
    this.shopService.setShopParams(params);
    this.getProducts();
  }
  // shop.service.ts 
  getProductTypes() {
    this.shopService.getProductTypes().subscribe(response => {
      this.productTypeList = response.data.filter(productType =>
        productType.level === 0
      )

      this.productTypeList.forEach(productType => productType.childType = []);
      response.data
        .filter(productTypes => productTypes.level === 1)
        .forEach(level1 => {
          this.productTypeList.forEach(productType => {
            if (level1.parentId === productType.id) {
              productType.childType.push(level1);
            }
          })
        })
    }, error => {
      console.log(error);
    });
  }

  getProducts() {
    this.shopService.getProducts().subscribe(response => {
      this.products = response.body?.data!; // 有可能為空值，加上!
      // const headers = response.headers.keys(); 取出物件中的key，{key:value}
      var xpaginationString = response.headers.get('x-pagination')!;
      this.paginationParams = JSON.parse(xpaginationString);
    }, error => {
      if (error.error.statusCode===404) {
        this.products = [];
        this.shopParams = new ShopParams();
        this.paginationParams = new PaginationParams();
        this.error = error.error.message;
      }
    });
  }
}
