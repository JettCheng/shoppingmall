import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CheckoutSuccessComponent } from './checkout-success/checkout-success.component';
import { CheckoutComponent } from './checkout.component';

const routes: Routes = [
  {path: '', component: CheckoutComponent},
  {path: 'success', component: CheckoutSuccessComponent, data: {breadcrumb: '訂單已送出'}}

]


@NgModule({
  declarations: [],
  imports: [
    RouterModule.forChild(routes)    
  ],
  exports: [
    RouterModule
  ]

})
export class CheckoutRoutingModule { }