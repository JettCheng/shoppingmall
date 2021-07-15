import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { IProduct } from 'src/app/shared/models/product';
import { IProductType } from 'src/app/shared/models/productType';
import { ShopService } from 'src/app/shop/shop.service';
import { BreadcrumbService } from 'xng-breadcrumb';

@Component({
  selector: 'app-product-update',
  templateUrl: './product-update.component.html',
  styleUrls: ['./product-update.component.scss']
})
export class ProductUpdateComponent implements OnInit {
  productForUpdateForm: FormGroup;
  product: IProduct;
  productTypeLevel0: IProductType[];
  productTypeLevel1: IProductType[];
  initialProductTypeOption: IProductType =  {id: '', level: 0, parentId: '', name: '請選擇', childType: []}


  constructor(
      private fb: FormBuilder, 
      private activateRoute: ActivatedRoute, 
      private shopService: ShopService, 
      private bcService: BreadcrumbService) { }

  ngOnInit(): void {
    this.initialProductForUpdateForm();
    this.loadProduct();
    this.getProductTypes();
  }

  private setFormValue() {
    this.productForUpdateForm.get('title').setValue(this.product.title);
    this.productForUpdateForm.get('originalPrice').setValue(this.product.originalPrice);
    this.productForUpdateForm.get('description').setValue(this.product.description);
    this.productForUpdateForm.get('productTypeId').setValue(this.product.productType.id);
    this.product.productImages.forEach(i => {
      // console.log(i);
      (<FormArray>this.productForUpdateForm.get('productImages')).push(
        this.fb.group({i})
      )  
    })
  }

  private initialProductForUpdateForm() {    
    this.productForUpdateForm = this.fb.group({
      title: [null, [Validators.required]],
      description: [null, [Validators.required]],
      originalPrice: [null, [Validators.required, Validators.pattern('^[0-9]*$')]],
      productTypeId: [null],
      coverImage: [null],
      productImages: this.fb.array([]),
      url: [null]
    })
  }

  private loadProduct() {
    const id = this.activateRoute.snapshot.paramMap.get('id');
    this.shopService.getProduct(id!).subscribe(response => {    
      this.product = response.data;
      this.setFormValue();
      this.bcService.set('@productDetails', this.product.title);
    }, error => {
      console.log(error);
    })
  }

  private getProductTypes() {
    this.shopService.getProductTypes().subscribe(response => {
      this.productTypeLevel0 = response.data.filter(type =>
        type.level === 0
      )
      this.productTypeLevel1 = response.data.filter(type =>
        type.level === 1
      )
      this.productTypeLevel0.unshift(this.initialProductTypeOption);
    }, error => {
      console.log(error);
    });
  }
}
