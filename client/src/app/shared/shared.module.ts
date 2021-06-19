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


const ChartjsModuleImport = [
    CommonModule,
    ChartsModule.forRoot({
      defaults: {},
      plugins: [ Annotation ]
    }),
    MarkdownModule.forRoot({ loader: HttpClient }),
    HighlightModule
]

@NgModule({
  declarations: [
    LineChartComponent,
    BarChartComponent
  ],
  imports: [
    CommonModule,
    ChartjsModuleImport
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
    LineChartComponent,
    BarChartComponent,
    HighlightModule,
    ChartsModule
  ]
})

export class SharedModule { }

export function hljsLanguages(): { [name: string]: Partial<LanguageFn> } {
  return {
    typescript: () => import('highlight.js/lib/languages/typescript'),
    xml: () => import('highlight.js/lib/languages/xml')
  };
}