import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavBarComponent } from './components/nav-bar/nav-bar.component';
import { SectionHeaderComponent } from './components/section-header/section-header.component';
import { RouterModule } from '@angular/router';
import { SharedModule } from '../shared/shared.module';
import { BreadcrumbModule } from 'xng-breadcrumb';



@NgModule({
  declarations: [
    NavBarComponent,
    SectionHeaderComponent
  ],
  imports: [
    CommonModule,
    RouterModule,
    SharedModule,
    BreadcrumbModule,
  ], 
  exports: [
    NavBarComponent,
    SectionHeaderComponent
  ]
})
export class CoreModule { }
