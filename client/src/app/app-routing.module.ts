import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AboutMeComponent } from './about-me/about-me.component';
import { AboutSiteComponent } from './about-site/about-site.component';
import { AuthGuard } from './core/guards/auth.guard';
import { HomeComponent } from './home/home.component';

const routes: Routes = [
  { 
    path: '', component: HomeComponent,
    data: { breadcrumb: '首頁' }
  },
  { 
    path: 'about-me', component: AboutMeComponent,
    data: { breadcrumb: '關於我' }
  },
  { 
    path: 'about-site', component: AboutSiteComponent,
    data: { breadcrumb: '關於網站' }
  },
  {
    path: 'shop', 
    loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule),
    data: { breadcrumb: '線上商城' }
  },
  {
    path: 'basket', 
    loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule),
    data: { breadcrumb: '我的購物車' }
  },
  {
    path: 'checkout', 
    canActivate: [AuthGuard],
    loadChildren: () => import('./checkout/checkout.module').then(mod => mod.CheckoutModule),
    data: { breadcrumb: '結帳' }
  },
  {
    path: 'orders', 
    canActivate: [AuthGuard],
    loadChildren: () => import('./order/order.module').then(mod => mod.OrderModule),
    data: { breadcrumb: '我的訂單' }
  },
  {
    path: 'account', 
    loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule),
    data: { breadcrumb: {skip: true} }
  },
  {
    path: 'product-management', 
    canActivate: [AuthGuard],
    loadChildren: () => import('./cms/cms.module').then(mod => mod.CmsModule),
    data: { breadcrumb: '商品管理' }
  },

  { path: '**', redirectTo: 'not-found', pathMatch: 'full' }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
