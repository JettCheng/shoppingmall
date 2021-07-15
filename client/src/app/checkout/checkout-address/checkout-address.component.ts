import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/account/account.service';
import { IAddress } from 'src/app/shared/models/address';

@Component({
  selector: 'app-checkout-address',
  templateUrl: './checkout-address.component.html',
  styleUrls: ['./checkout-address.component.scss']
})
export class CheckoutAddressComponent implements OnInit {
  @Input() checkoutForm: FormGroup; // 若需操作 checkout form 則這邊開接口

  constructor(private accountService: AccountService, private toastr: ToastrService
  ) { }

  ngOnInit(): void {
  }

  saveUserAddress() {
    this.accountService.updateUserAddress(this.checkoutForm.get('addressForm').value).subscribe((address: IAddress) => {
      this.toastr.success('地址已儲存');
      this.checkoutForm.get('addressForm').reset(address);
    }, error => {
      this.toastr.error('建立失敗，您有必填資料尚未填寫');
      console.log(error);
    })
  }

}
