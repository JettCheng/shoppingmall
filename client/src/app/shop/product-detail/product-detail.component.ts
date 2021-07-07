import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { BasketService } from 'src/app/basket/basket.service';
import { IProduct } from 'src/app/shared/models/product';
import { BreadcrumbService } from 'xng-breadcrumb';
import { ShopService } from '../shop.service';

@Component({
  selector: 'app-product-detail',
  templateUrl: './product-detail.component.html',
  styleUrls: ['./product-detail.component.scss']
})
export class ProductDetailComponent implements OnInit {
  product!: IProduct;
  quantity:number = 1;
  constructor(
    private shopService: ShopService, 
    private activateRoute: ActivatedRoute, 
    private bcService: BreadcrumbService,
    private basketService: BasketService
  ) 
  {
    this.bcService.set('@productDetails', ' ')
  }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    this.shopService.getProduct(id!).subscribe(response => {    
      console.log(response)

      this.product = response.data;
      this.bcService.set('@productDetails', this.product.title);
    }, error => {
      console.log(error);
    })
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    if (this.quantity > 1) {
      this.quantity--;
    }
  }

  addItemToBasket() {
    console.log(this.product)
    this.basketService.addItemToBasket(this.product, this.quantity);
  }
}
