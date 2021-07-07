import { HttpClient, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Basket, IBasket, IBasketItem, IBasketTotals } from '../shared/models/basket';
import { IProduct } from '../shared/models/product';
import { IResponse } from '../shared/models/response';

@Injectable({
  providedIn: 'root'
})
export class BasketService {
  baseUrl = environment.apiUrl;
  private basketSource = new BehaviorSubject<IBasket>(null!);
  basket$ = this.basketSource.asObservable();
  private basketTotalSource = new BehaviorSubject<IBasketTotals>(null!);
  basketTotal$ = this.basketTotalSource.asObservable();
  shipping = 0;

  constructor(private http: HttpClient) { }

  // setShippingPrice(deliveryMethod: IDeliveryMethod) {
  //   this.shipping = deliveryMethod.price;
  //   const basket = this.getCurrentBasketValue();
  //   basket.deliveryMethodId = deliveryMethod.id;
  //   basket.shippingPrice = deliveryMethod.price;
  //   this.calculateTotals();
  //   this.setBasket(basket);
  // }
  
  getBasket(id: string) {
    let params = new HttpParams();
    params = params.append('id', id)
    return this.http.get<IResponse<IBasket>> (this.baseUrl + 'basket', {params})
      .pipe(
        map((response) => {
          this.basketSource.next(response.data);
          this.shipping = response.data.shippingPrice!;
          this.calculateTotals();
        })
      )
  }

  setBasket(basket: IBasket) {
    return this.http.post<IResponse<IBasket>>(this.baseUrl + 'basket', basket).subscribe((response) => {
      console.log(response)
      console.log(response.statusCode)
      console.log(response.data)
      this.basketSource.next(response.data);
      this.calculateTotals();
    }, error => {
      console.log(error);
    })
  }

  getCurrentBasketValue() {
    return this.basketSource.value;
  }

  addItemToBasket(item: IProduct, quantity = 1) {
    const itemToAdd: IBasketItem = this.mapProductItemToBasketItem(item, quantity);
    const basket = this.getCurrentBasketValue() ?? this.createBasket();
    basket.items = this.addOrUpdateItem(basket.items, itemToAdd, quantity);
    this.setBasket(basket);
  }

  incrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(x => x.id === item.id);
    basket.items[foundItemIndex].quantity++;
    this.setBasket(basket);
  }

  decrementItemQuantity(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    const foundItemIndex = basket.items.findIndex(x => x.id === item.id);
    if (basket.items[foundItemIndex].quantity > 1) {
      basket.items[foundItemIndex].quantity--;
      this.setBasket(basket);
    } else {
      this.removeItemFromBasket(item);
    }
  }

  removeItemFromBasket(item: IBasketItem) {
    const basket = this.getCurrentBasketValue();
    if (basket.items.some(x => x.id === item.id)) {
      basket.items = basket.items.filter(i => i.id !== item.id);
      if (basket.items.length > 0) {
        this.setBasket(basket);
      } else {
        this.deleteBasket(basket); 
      }
    }
  }

  deleteLocalBasket(id: string) {
    this.basketSource.next(null!);
    this.basketTotalSource.next(null!);
    localStorage.removeItem('basket_id');
  }

  deleteBasket(basket: IBasket) {
    return this.http.delete(this.baseUrl + 'basket?id=' + basket.id).subscribe(() => {
      this.basketSource.next(null!);
      this.basketTotalSource.next(null!);
      localStorage.removeItem('basket_id');
    }, error => {
      console.log(error);
    })
  }

  private calculateTotals() {
    const basket = this.getCurrentBasketValue();
    const shipping = this.shipping;
    const subtotal = basket.items.reduce((a, b) => (b.price * b.quantity) + a, 0);
    const total = subtotal + shipping;
    this.basketTotalSource.next({shipping, total, subtotal});
  }


  private addOrUpdateItem(items: IBasketItem[], itemToAdd: IBasketItem, quantity: number): IBasketItem[] {
    const index = items.findIndex(i => i.id === itemToAdd.id);
    if (index === -1) {
      itemToAdd.quantity = quantity;
      items.push(itemToAdd);
    } else {
      items[index].quantity += quantity;
    }
    // console.log(items);
    // console.log(itemToAdd);
    return items;
  }

  private createBasket(): IBasket {
    const basket = new Basket();
    localStorage.setItem('basket_id', basket.id);
    return basket;
  }

  private mapProductItemToBasketItem(item: IProduct, quantity: number): IBasketItem {
    return {
      id: item.id,
      productTitle: item.title,
      price: item.originalPrice,
      coverImage: item.coverImageUrl,
      quantity,
      type: item.productType.name
    }
  }
}
