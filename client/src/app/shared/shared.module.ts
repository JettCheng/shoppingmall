import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AccordionModule } from 'ngx-bootstrap/accordion';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';

import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { NgxSpinnerModule } from 'ngx-spinner';

import { PaginationModule } from 'ngx-bootstrap/pagination';
import { PagerComponent } from './components/pager/pager.component';
import { TextInputComponent } from './components/text-input/text-input.component';
import { BasketSummaryComponent } from './components/basket-summary/basket-summary.component';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';


const bootstrapModules = [
  AccordionModule.forRoot(),
  CarouselModule.forRoot(),
  BsDropdownModule.forRoot(),

];
const ngxModules = [
  PaginationModule.forRoot(),
  NgxSpinnerModule
]
const components = [
  PagingHeaderComponent,
  PagerComponent,
  TextInputComponent,
  BasketSummaryComponent,
]

@NgModule({
  declarations: [
    components
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    bootstrapModules,
    ngxModules,
  ],
  exports:[
    ReactiveFormsModule,
    components,
    bootstrapModules,
    ngxModules,
  ]
})
export class SharedModule { }
