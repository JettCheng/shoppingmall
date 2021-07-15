import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
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
  galleryOptions: NgxGalleryOptions[] = [];
  galleryImages: NgxGalleryImage[] = [];
  product: IProduct;
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
    this.galleryOptions = [
      {
        width: '600px',
        height: '600px',
        thumbnailsColumns: 4,
        arrowPrevIcon: 'fa fa-chevron-left',
        arrowNextIcon: 'fa fa-chevron-right',
        imageAnimation: NgxGalleryAnimation.Slide
      },
      // max-width 800
      {
        breakpoint: 800,
        width: '100%',
        height: '600px',
        imagePercent: 80,
        thumbnailsPercent: 20,
        thumbnailsMargin: 20,
        thumbnailMargin: 20
      },
      // max-width 400
      {
        breakpoint: 400,
        preview: false
      }
    ];
  }

  setProductImage(url: string) {
    const gi = {
      small: url,
      medium: url,
      big: url
    };
    this.galleryImages.push(gi);
  }

  loadProduct() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    this.shopService.getProduct(id!).subscribe(response => {    
      this.product = response.data;
      if(response.data.productImages.length>0) {
        response.data.productImages.map(pi => {
          this.setProductImage(pi.url)
        })
      } else {
        this.setProductImage("data:image/png;base64,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")
      }
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
