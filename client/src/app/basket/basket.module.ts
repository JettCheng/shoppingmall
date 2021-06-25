import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BasketComponent } from './basket.component';
import { SharedModule } from '../shared/shared.module';
import { BasketRoutingModule } from './basket-routing.module';



@NgModule({
  declarations: [
    BasketComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    // 由於 basket 設定為 lazyloading (由 BasketRoutingModule 擔當load basket的職責)
    // 因此需要 import BasketRoutingModule，BasketRoutingModule 才能夠 load 到 BasketModule 
    BasketRoutingModule
  ],
})
export class BasketModule { }
