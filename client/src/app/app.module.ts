import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { ChartsModule } from 'ng2-charts';
import { Route, RouterModule } from '@angular/router';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { MarkdownModule } from 'ngx-markdown';

import 'highlight.js';
import { HIGHLIGHT_OPTIONS, HighlightModule } from 'ngx-highlightjs';

import { AppComponent } from './app.component';
import { LineChartComponent } from './line-chart/line-chart.component';
import { BarChartComponent } from './bar-chart/bar-chart.component';

import { default as Annotation } from 'chartjs-plugin-annotation';

const routes: Route[] = [];

export function hljsLanguages(): { [name: string]: Partial<LanguageFn> } {
  return {
    typescript: () => import('highlight.js/lib/languages/typescript'),
    // html: import('highlight.js/lib/languages/html'),
    // scss: import('highlight.js/lib/languages/scss'),
    xml: () => import('highlight.js/lib/languages/xml')
  };
}

@NgModule({
  declarations: [
    AppComponent,
    LineChartComponent,
    BarChartComponent,
  ],
  imports: [
    BrowserModule,
    RouterModule.forRoot(routes),
    ChartsModule.forRoot({
      defaults: {},
      plugins: [ Annotation ]
    }),
    MarkdownModule.forRoot({ loader: HttpClient }),
    BrowserAnimationsModule,
    HttpClientModule,
    HighlightModule
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
  bootstrap: [ AppComponent ]
})
export class AppModule {
}
