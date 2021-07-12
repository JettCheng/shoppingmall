import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { IResponse } from '../shared/models/response';
import { IOrder } from '../shared/models/order';


@Injectable({
  providedIn: 'root'
})
export class OrderService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  getOrdersForUser() {
    return this.http.get<IResponse<IOrder[]>>(this.baseUrl + 'orders');
  }

  getOrderDetailed(id: string) {
    return this.http.get<IResponse<IOrder>>(this.baseUrl + 'orders/' + id);
  }
}
