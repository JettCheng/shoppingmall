import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';
import { CmsComponent } from './cms.component';
import { ProductCreationComponent } from './product-creation/product-creation.component';
import { ProductUpdateComponent } from './product-update/product-update.component';

const routes: Routes = [
  { path: '', component: CmsComponent },
  { path: 'creation', component: ProductCreationComponent, data: {breadcrumb: '新增商品' }},
  { path: 'update/:id', component: ProductUpdateComponent, data: {breadcrumb: '修改商品' }},
]

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes),
  ],
  exports: [
    RouterModule
  ]
})
export class CmsRoutingModule { }
