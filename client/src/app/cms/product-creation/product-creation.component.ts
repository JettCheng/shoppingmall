import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { FormControl, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgxGalleryAction, NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { ToastrService } from 'ngx-toastr';
import { IProduct } from 'src/app/shared/models/product';
import { IProductType } from 'src/app/shared/models/productType';
import { ShopService } from 'src/app/shop/shop.service';


@Component({
  selector: 'app-product-creation',
  templateUrl: './product-creation.component.html',
  styleUrls: ['./product-creation.component.scss']
})
export class ProductCreationComponent implements OnInit {
  productForCreationForm: FormGroup;
  product: IProduct;
  productTypeLevel0: IProductType[];
  productTypeLevel1: IProductType[];
  initialProductTypeOption: IProductType =  {id: '', level: 0, parentId: '', name: '請選擇', childType: []}

  // gallery
  galleryOptions: NgxGalleryOptions[] = [];
  galleryImages: NgxGalleryImage[] = [];
  
  // returnUrl: string;  
  // errors: string[];
  // productTypeLevel0: IProductType[] = [];
  // productTypeLevel1: IProductType[] = [];
  // initialProductTypeOption: IProductType;
  // productTypeLevel0Selected = '';
  // productTypeLevel1Selected = '';
  // productTypeLevel1Filted: IProductType[] = [];
  // isImageEmpty = true;

  constructor(
    private fb: FormBuilder, 
    private shopService: ShopService,
    private toastr: ToastrService

  ) { }

  ngOnInit(): void {
    this.initialProductForCreationForm();
    this.getProductTypes();
  }

  private initialProductForCreationForm() {
    this.productForCreationForm = this.fb.group({
      title: [null, [Validators.required]],
      description: [null, [Validators.required]],
      originalPrice: [null, [Validators.required, Validators.pattern('^[0-9]*$')]],
      productTypeId: [null],
      coverImage: [null],
      productImages: this.fb.array([]),
      url: [null]
    });
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

  // onSetLocalProductImage(url: string) {
  //   if(this.productForCreationForm.get('url').value===null) return;
  //   if(this.isImageEmpty) this.galleryImages.shift();
  //   const gi = {
  //     small: url,
  //     medium: url,
  //     big: url
  //   };
  //   this.galleryImages.push(gi);
  //   this.isImageEmpty = false
  //   this.productForCreationForm.get('url').reset();
  // }

  // onDeleteLocalProductImage(index: number) {
  //   this.galleryImages.splice(index,1);
  //   this.isProductImageEmpty();
  // }
  
  // onSubmit() {
  //   if(this.productForCreationForm.invalid) {
  //     if(this.productTypeLevel1Selected==='') this.toastr.error('請選擇商品分類');
  //   }
  //   this.productForCreationForm.get('productTypeId').setValue(this.productTypeLevel1Selected)
  //   this.galleryImages.forEach(i => {
  //     (<FormArray>this.productForCreationForm.get('productImages')).push(
  //       this.fb.group({url: i.small})
  //     )
  //   })
  //   this.productForCreationForm.get('coverImage').setValue(this.galleryImages[1].small);
  //   console.log((this.productForCreationForm.value));
  //   this.shopService.createProduct(this.productForCreationForm.value).subscribe(response => {
  //     this.productForCreationForm.reset();
  //     this.toastr.success('建立成功');
  //     this.galleryImages=[]
  //   }, error => {
  //     this.toastr.error('建立失敗');
  //     console.log(error);
  //     this.errors = error.message;
  //   });
  // }
  
  // onProductTypeLevel0Selected(typeId: string) {
  //   this.productTypeLevel0Selected = typeId;
  //   this.filtProductTypeLevel1(typeId);
  // }

  // onProductTypeLevel1Selected(typeId: string) {
  // this.productTypeLevel1Selected = typeId;
  // }

  // filtProductTypeLevel1(parentId: string) {
  //   this.productTypeLevel1Filted = this.productTypeLevel1.filter( type => type.parentId === parentId);
  //   this.productTypeLevel1Filted.unshift(this.initialProductTypeOption);    
  // }
}
