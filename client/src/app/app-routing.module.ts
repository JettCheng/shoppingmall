import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutMeComponent } from './about-me/about-me.component';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { 
    path: '', component: HomeComponent,
    data: { breadcrumb: {skip: true} }
  },
  { 
    path: 'aboutme', component: AboutMeComponent,
    data: { breadcrumb: {skip: true} }
  },
  {
    path: 'shop', loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule),
    data: { breadcrumb: '商品' }
  },
  {
    path: 'basket', loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule),
    data: { breadcrumb: '購物車' }
  },
  // {
  //   path: 'checkout', 
  //   canActivate: [AuthGuard],
  //   loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule),
  //   data: { breadcrumb: 'Checkout' }
  // },
  // {
  //   path: 'orders', 
  //   canActivate: [AuthGuard],
  //   loadChildren: () => import('./orders/orders.module').then(mod => mod.OrdersModule),
  //   data: { breadcrumb: 'Orders' }
  // },
  {
    path: 'account', loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule),
    data: { breadcrumb: {skip: true} }
  },
  { path: '**', redirectTo: 'not-found', pathMatch: 'full' }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
