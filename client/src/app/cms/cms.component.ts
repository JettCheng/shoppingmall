import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { PaginationParams } from '../shared/models/paginationParams';
import { IProduct } from '../shared/models/product';
import { IProductType } from '../shared/models/productType';
import { ShopParams } from '../shared/models/shopParams';
import { ShopService } from '../shop/shop.service';

@Component({
  selector: 'app-cms',
  templateUrl: './cms.component.html',
  styleUrls: ['./cms.component.scss']
})
export class CmsComponent implements OnInit {
  @ViewChild('search', { static: false }) searchTerm!: ElementRef;

  paginationParams = {
    PageIndex:3,
    TotalCount:30,
    PageSize:5
  }
  products: IProduct[] = [];
  shopParams: ShopParams = new ShopParams();  
  error: string;  
  productTypeList: IProductType[] = [];

  constructor(private shopService: ShopService, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.getProducts();   
    this.getProductTypes();
  }
  
  removeProduct(productId: string) {
    this.shopService.removeProduct(productId).subscribe(response => {
      this.toastr.success('刪除成功');
      this.products.forEach(p => {
        if(p.id===productId) this.products.splice(this.products.indexOf(p));
      })
    }, error => {
      console.log(error)
    })
  }
  
  editProduct() {
    
  }

  onProductTypeSelected(id: string) {
    if(id===null) return;
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
    //   @ViewChild('search', { static: false }) searchTerm!: ElementRef; 要在上面加這行才有辦法控制原生ＨＴＭＬ
    shopParams.keyword = this.searchTerm.nativeElement.value;
    paginationParams.PageIndex = 1
    this.shopService.setShopParams(shopParams);
    this.shopService.setPaginationParams(paginationParams);
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
  
  getProducts() {
    this.shopService.getProducts().subscribe(response => {
      this.products = response.body.data; // 有可能為空值，加上!
      // const headers = response.headers.keys(); 取出物件中的key，{key:value}
      var xpaginationString = response.headers.get('x-pagination')!;
      this.paginationParams = JSON.parse(xpaginationString);
      console.log(response.body.data)
    }, error => {
      if (error.error.statusCode===404) {
        this.products = [];
        this.shopParams = new ShopParams();
        this.paginationParams = new PaginationParams();
        this.error = error.error.message;
      }
    });
  }

  getProductTypes() {
    this.shopService.getProductTypes().subscribe(response => {
      this.productTypeList = response.data.filter(productType =>
        productType.level === 1
      )
      console.log(this.productTypeList)
      this.productTypeList.unshift({id:'', name: '全部', level: 1, parentId: '', childType: null})
    }, error => {
      console.log(error);
    });
  }
}
