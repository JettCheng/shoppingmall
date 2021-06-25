import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { AppComponent } from './app.component';
import { SharedModule } from './shared/shared.module';
import { CoreModule } from './core/core.module';
import { HomeModule } from './home/home.module';
import { AppRoutingModule } from './app-routing.module';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoadingInterceptor } from './core/interceptors/loading.interceptor';
import { ShopChartsModule } from './shop-charts/shop-charts.module';
import { JwtInterceptor } from './core/interceptors/jwt.interceptor';


@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    BrowserAnimationsModule,
    BrowserModule,
    AppRoutingModule, // 少了這個 router-outlet 不會正常顯示
    SharedModule,
    CoreModule, 
    HomeModule,
    HttpClientModule,
    ShopChartsModule 
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: LoadingInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true }
  ],
  bootstrap: [ AppComponent ]
})
export class AppModule {
}
