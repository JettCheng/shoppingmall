import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: 'login', component: LoginComponent, data: { breadcrumb: '登入' }},
  {path: 'register', component: RegisterComponent, data: { breadcrumb: '註冊會員' }}
]

@NgModule({
  declarations: [],
  imports: [
    // CommonModule, // routing 不需要 common
    RouterModule.forChild(routes)
  ],
  exports: [
    RouterModule
  ]
})
export class AccountRoutingModule { }
