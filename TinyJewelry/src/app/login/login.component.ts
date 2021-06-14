import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup, Validators, FormBuilder} from '@angular/forms';
import { AuthService } from '../core/services/authService';
import { CustomerService } from '../core/services/customerService';
import { Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { User } from 'src/app/core/model/user';
import { InformationComponent } from 'src/app/core/component/information.component';
@Component({
  selector: 'tiny-jewel-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  constructor(private formBuilder: FormBuilder, private authService: AuthService,
     private customerService: CustomerService, private router: Router, private dialog: MatDialog) {}
  
  frmGroup = this.formBuilder.group({
    userName: new FormControl('', Validators.required),
    password: new FormControl('',Validators.required)
  });

  ngOnInit() {
   
  }

  ValidateUser() {
    this.frmGroup.markAllAsTouched();
    if(this.frmGroup.valid) {
      const obj = new User(this.frmGroup.value.userName, this.frmGroup.value.password, '');
      this.authService.ValidateUser(obj).subscribe(data => {
        if(data && data.jwtToken) {   
          this.authService.setUserDetail(data);
          this.router.navigate(['/customer']);
        } else {
          this.dialog.open(InformationComponent,{
            data: "Username or Password is invalid.!",
            panelClass: 'dialogClass'
          });
        }
      });
      // var cust = new customer("TestNormalUser",2,"Normal");
      // this.customerService.SetCustomerDetails(cust);
      // this.router.navigate(['/customer']);
    } else {
      this.dialog.open(InformationComponent,{
        data: "Username or Password is invalid.!",
        panelClass: 'dialogClass'
      });
    }
  }
  
  ResetLogin() {
    this.frmGroup.reset();
  }
}

