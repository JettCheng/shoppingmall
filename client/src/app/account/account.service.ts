import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { of, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IAddress } from '../shared/models/address';
import { IResponse } from '../shared/models/response';
import { IUser } from '../shared/models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl;
  private currentUserSource = new ReplaySubject<IUser>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient, private router: Router) { }

  // 當 account.module.ts 被懶載入後，先從 localstorage load token
  loadCurrentUser(token: string) {
    // 如果 load 不到，就 next 一個 null
    if (token===null) {
      this.currentUserSource.next(null);
      return of(null);
    }

    // 拿 token 回去跟 API 換一個新的，若成功則同時更新 localstorage 的 token，並 next 一個 user
    // 如果有寫 jwt.interceptor 以下附 header 的 code 可省略
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${token}`);
    return this.http.get<IResponse<IUser>>(this.baseUrl + 'account', {headers}).pipe(
    // return this.http.get<IResponse<IUser>>(this.baseUrl + 'account').pipe(
      map(response => {          
        if(response.data) {      
          localStorage.setItem('token', response.data.accessToken);
          this.currentUserSource.next(response.data);
        }
      })
    )
  }

  login(values: any) {
    // let headers = new HttpHeaders();
    // headers = headers.set('Content-Type', 'application/json');
    // headers = headers.set('Accept', 'application/json');
    return this.http.post<IResponse<IUser>>(this.baseUrl + 'account/login', values).pipe(
      map((response) => {
        if (response.data) {
          localStorage.setItem('token', response.data.accessToken);
          console.log(response.data)
          this.currentUserSource.next(response.data);
        }
      })
    )
  }

  register(values: any) {
    return this.http.post<IResponse<IUser>>(this.baseUrl + 'account/register', values).pipe(
      map((response) => {
        if (response.data) {
          localStorage.setItem('token', response.data.accessToken);
          this.currentUserSource.next(response.data);
        }
      })
    )
  }

  logout() {
    localStorage.removeItem('token');
    this.currentUserSource.next(null!);
    this.router.navigateByUrl('/');
  }

  checkEmailExists(email: string) {
    return this.http.get(this.baseUrl + 'account/emailexists?email=' + email);
  }

  getUserAddress() {
    return this.http.get<IAddress>(this.baseUrl + 'account/address');
  }

  updateUserAddress(address: IAddress) {
    return this.http.put<IAddress>(this.baseUrl + 'account/address', address);
  }
}
