import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductDetailComponent } from './product-detail/product-detail.component';
import { ShopComponent } from './shop.component';

const routes: Routes = [
  { path: '', component: ShopComponent },
  { path: ':id', component: ProductDetailComponent, data: {breadcrumb: {alias: 'productDetails'} }}
];

@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes) // 表示這個 module 無法再被 app.module 使用，儘可以被 shop.module 使用
  ],
  exports: [
    RouterModule
  ]
})
export class ShopRoutingModule { }
