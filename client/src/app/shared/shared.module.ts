import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChartsModule } from 'ng2-charts';
import { MarkdownModule } from 'ngx-markdown';
import { default as Annotation } from 'chartjs-plugin-annotation';
import { HttpClient } from '@angular/common/http';
import { BarChartComponent } from './components/bar-chart/bar-chart.component';
import { LineChartComponent } from './components/line-chart/line-chart.component';
import { HighlightModule, HIGHLIGHT_OPTIONS } from 'ngx-highlightjs';
import 'highlight.js';
import { AccordionModule } from 'ngx-bootstrap/accordion';
import { PaginationModule } from 'ngx-bootstrap/pagination';
import { NgxSpinnerModule } from 'ngx-spinner';
import { CarouselModule } from 'ngx-bootstrap/carousel';
import { PagingHeaderComponent } from './components/paging-header/paging-header.component';
import { PagerComponent } from './components/pager/pager.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TextInputComponent } from './components/text-input/text-input.component';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { BasketSummaryComponent } from './components/basket-summary/basket-summary.component';
import { RouterModule } from '@angular/router';


const chartjsModule = [
    CommonModule,
    ChartsModule.forRoot({
      defaults: {},
      plugins: [ Annotation ]
    }),
    MarkdownModule.forRoot({ loader: HttpClient }),
    HighlightModule
];
const bootstrapModule = [
  AccordionModule.forRoot(),
  CarouselModule.forRoot(),
  BsDropdownModule.forRoot(),

];
const ngxModule = [
  PaginationModule.forRoot(),
  NgxSpinnerModule
]
const Components = [
  LineChartComponent,
  BarChartComponent,
  PagingHeaderComponent,
  PagerComponent,
  TextInputComponent,
  BasketSummaryComponent
]

@NgModule({
  declarations: [
    Components,
  ],
  imports: [
    CommonModule,    
    FormsModule,
    ReactiveFormsModule,
    RouterModule,
    chartjsModule,
    bootstrapModule,
    ngxModule
  ],
  providers: [
    {
      provide: HIGHLIGHT_OPTIONS,
      useValue: {
        coreLibraryLoader: () => import('highlight.js/lib/core'),
        languages: hljsLanguages()
      }
    }
  ],
  exports: [
    // FormsModule,
    ReactiveFormsModule,
    HighlightModule,
    ChartsModule,
    Components,
    bootstrapModule,
    ngxModule,
  ]
})

export class SharedModule { }

export function hljsLanguages(): { [name: string]: Partial<LanguageFn> } {
  return {
    typescript: () => import('highlight.js/lib/languages/typescript'),
    xml: () => import('highlight.js/lib/languages/xml')
  };
}