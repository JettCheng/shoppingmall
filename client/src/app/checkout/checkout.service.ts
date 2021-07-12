import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { IDeliveryMethod } from '../shared/models/deliveryMethod';
import { IOrderToCreate } from '../shared/models/order';
import { IResponse } from '../shared/models/response';

@Injectable({
  providedIn: 'root'
})
export class CheckoutService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) { }

  createOrder(order: IOrderToCreate) {
    return this.http.post(this.baseUrl + 'orders', order);
  }

  getDeliveryMethods() {
    return this.http.get<IResponse<IDeliveryMethod[]>>(this.baseUrl + 'orders/deliveryMethods').pipe(
      map(response => {
        return response.data.sort((a, b) => b.price - a.price);
      })
    )
  }
}
// IResponse<IDeliveryMethod[]>
