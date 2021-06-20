import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ShopChartsComponent } from './shop-charts.component';
import { SharedModule } from '../shared/shared.module';



@NgModule({
  declarations: [
    ShopChartsComponent
  ],
  imports: [
    CommonModule,
    SharedModule
  ], 
  exports: [
    ShopChartsComponent
  ]
})
export class ShopChartsModule { }
