import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {
  registerForm: FormGroup;
  errors: string[];
  
  constructor(
    private fb: FormBuilder, 
    private accountService: AccountService, 
    private router: Router
  ) { }

  ngOnInit(): void {
    this.createRegisterForm();
  }
  
  createRegisterForm() {
    this.registerForm = this.fb.group({
      name: [null, [Validators.required]],
      email: [null, 
        [Validators.required, Validators
        .pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')],
        // [this.validateEmailNotTaken()]
      ],
      password: [null, Validators.required]
    });
  }

  onSubmit() {
    this.accountService.register(this.registerForm.value).subscribe(response => {
      this.router.navigateByUrl('/shop');
    }, error => {
      console.log(error);
      this.errors = error.errors;
    })
  }

}