import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ShopChartsComponent } from './shop-charts/shop-charts.component';

const routes: Routes = [
  { 
    path: '',
    component: HomeComponent, 
    data: {breadcrumb: '首頁'} 
  },
  { 
    path: 'shop',
    loadChildren: () => import('./shop/shop.module').then(mod => mod.ShopModule),
    data: {breadcrumb: '線上商城'}
  },
  {
    path: 'account',
    loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule), 
    data: { breadcrumb: {skip: true} }
  },
  {
    path: 'basket',
    loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule), 
    data: { breadcrumb: '購物車' }
  },
  // {
  //   path: 'basket',
  //   loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule), 
  //   data: { breadcrumb: '關於我' }
  // },
  // {
  //   path: 'basket',
  //   loadChildren: () => import('./basket/basket.module').then(mod => mod.BasketModule), 
  //   data: { breadcrumb: '後台管理' }
  // },
  { 
    path: 'chart', 
    component: ShopChartsComponent, 
    data: {breadcrumb: '報表圖表'}
  },
  // { 
  //   path: 'chart', 
  //   loadChildren: () => import('./shop-charts/shop-charts.module').then(mod => mod.ShopChartsModule), 
  //   data: {breadcrumb: '報表圖表'}
  // },
  //   path: 'account',
  //   loadChildren: () => import('./account/account.module').then(mod => mod.AccountModule),
  //   data: { breadcrumb: {skip: true} }
  // },
  { path: '**', redirectTo: '', pathMatch: 'full' }
];
@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
