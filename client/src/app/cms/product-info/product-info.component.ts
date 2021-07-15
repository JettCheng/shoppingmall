import { Component, EventEmitter, Input, OnChanges, OnInit, Output, SimpleChanges } from '@angular/core';
import { FormArray, FormBuilder, FormGroup } from '@angular/forms';
import { NgxGalleryAnimation, NgxGalleryImage, NgxGalleryOptions } from '@kolkov/ngx-gallery';
import { ToastrService } from 'ngx-toastr';
import { IProduct } from 'src/app/shared/models/product';
import { IProductType } from 'src/app/shared/models/productType';
import { ShopService } from 'src/app/shop/shop.service';

@Component({
  selector: 'app-product-info',
  templateUrl: './product-info.component.html',
  styleUrls: ['./product-info.component.scss']
})
export class ProductInfoComponent implements OnChanges {
  @Input() productInfoForm: FormGroup;
  @Input() productId: string;
  @Input() productTypeLevel0: IProductType[];
  @Input() productTypeLevel1: IProductType[];
  @Input() OperationType: number; // 0=create, 1=update

  @Output() update: EventEmitter<IProduct> = new EventEmitter<IProduct>();


  productTypeLevel0Selected = '';
  productTypeLevel1Selected = '';
  productTypeLevel1Filted: IProductType[] = [];
  isImageEmpty = true;

  // gallery
  galleryOptions: NgxGalleryOptions[] = [];
  galleryImages: NgxGalleryImage[] = [];

  initialProductTypeOption: IProductType = {id: '', level: 0, parentId: '', name: '請選擇', childType: []}

  constructor(private shopService: ShopService, private toastr: ToastrService, private fb: FormBuilder) { }
  ngOnChanges(changes: SimpleChanges): void {
    this.initialGalleryImages();
    this.setFormValue();
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if(this.productInfoForm.invalid) {
      if(this.productTypeLevel1Selected==='') this.toastr.error('請選擇商品分類');
    }
    this.productInfoForm.get('productTypeId').setValue(this.productTypeLevel1Selected)
    this.galleryImages.forEach(i => {
      (<FormArray>this.productInfoForm.get('productImages')).push(
        this.fb.group({url: i.small})
      )
    })
    this.productInfoForm.get('coverImage').setValue(this.galleryImages[1].small);
    if(this.OperationType===0) {
      this.shopService.createProduct(this.productInfoForm.value).subscribe(() => {
        this.productInfoForm.reset();
        this.toastr.success('建立成功');
        this.galleryImages=[]
      }, error => {
        this.toastr.error('建立失敗');
        console.log(error);
      });
    }
    if(this.OperationType===0) {
      this.shopService.updateProduct(this.productId,this.productInfoForm.value).subscribe(() => {
        this.productInfoForm.reset();
        this.toastr.success('建立成功');
        this.galleryImages=[]
      }, error => {
        this.toastr.error('建立失敗');
        console.log(error);
      });
    }
  }

  onDeleteLocalProductImage(index: number) {
    this.galleryImages.splice(index,1);
  }
  
  onProductTypeLevel0Selected(typeId: string) {
    this.productTypeLevel0Selected = typeId;
    this.filtProductTypeLevel1(typeId);
  }

  onProductTypeLevel1Selected(typeId: string) {
    this.productTypeLevel1Selected = typeId;
  }

  onSetLocalProductImage(url: string) {
    if(this.productInfoForm.get('url').value===null) return;
    if(this.isImageEmpty) this.galleryImages.shift();
    const gi = {
      small: url,
      medium: url,
      big: url
    };
    this.galleryImages.push(gi);
    this.isImageEmpty = false
    this.productInfoForm.get('url').reset();
  }

  private setFormValue() {
    console.log(this.productInfoForm.get('productImages').value);
    this.productInfoForm.get('productImages').value.forEach(i => {
      this.onSetLocalProductImage(i);
      console.log(i)    
      console.log(this.galleryImages)
    });
  } 

  private initialGalleryImages() {
    this.galleryOptions = [
      {
        width: '600px',
        height: '600px',
        thumbnailsColumns: 4,
        arrowPrevIcon: 'fa fa-chevron-left',
        arrowNextIcon: 'fa fa-chevron-right',
        imageAnimation: NgxGalleryAnimation.Slide
      }
    ];
  }

  private filtProductTypeLevel1(parentId: string) {
    this.productTypeLevel1Filted = this.productTypeLevel1.filter( type => type.parentId === parentId);
    this.productTypeLevel1Filted.unshift(this.initialProductTypeOption);    
  }
}
