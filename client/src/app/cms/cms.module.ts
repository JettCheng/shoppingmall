import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CmsComponent } from './cms.component';
import { CmsRoutingModule } from './cms-routing.module';
import { SharedModule } from '../shared/shared.module';
import { ProductCreationComponent } from './product-creation/product-creation.component';
import { ProductInfoComponent } from './product-info/product-info.component';
import { ProductUpdateComponent } from './product-update/product-update.component';



@NgModule({
  declarations: [
    CmsComponent,
    ProductCreationComponent,
    ProductInfoComponent,
    ProductUpdateComponent
  ],
  imports: [
    CommonModule,
    CmsRoutingModule,
    SharedModule
  ]
})
export class CmsModule { }
