import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { IOrder } from 'src/app/shared/models/order';
import { BreadcrumbService } from 'xng-breadcrumb';
import { OrderService } from '../order.service';

@Component({
  selector: 'app-order-detail',
  templateUrl: './order-detail.component.html',
  styleUrls: ['./order-detail.component.scss']
})
export class OrderDetailComponent implements OnInit {
  order: IOrder;

  constructor(private route: ActivatedRoute, private breadcrumbService: BreadcrumbService, 
    private orderService: OrderService) {
      this.breadcrumbService.set('@OrderDetailed', ' ');
     }

  ngOnInit(): void {
    this.orderService.getOrderDetailed(this.route.snapshot.paramMap.get('id'))
      .subscribe(response => {
        this.order = response.data;
        this.breadcrumbService.set('@OrderDetailed', `訂單編號# ${this.order.id} - ${this.order.status}`);
      }, error => {
        console.log(error);
      })
  }
}
