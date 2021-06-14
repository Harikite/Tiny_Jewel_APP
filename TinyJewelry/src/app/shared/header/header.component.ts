import { Component, OnInit, OnDestroy } from "@angular/core";
import { CustomerService } from '../../core/services/customerService';

@Component({
    selector: 'tiny-jewel-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit,OnDestroy  {
    UserType: string = '';
    showCustomer: boolean = false;
    constructor(private customerService: CustomerService) {
    }
    ngOnInit(): void {
        this.customerService.customerDetails$.subscribe(data => {
            if(data && data.customerType) {
                this.showCustomer = true;
                if (data.customerType === "1"){
                   this.UserType = 'Normal User'; 
                } else{
                    this.UserType = 'Privileged User'; 
                }
            } else {
                this.UserType = '';
                this.showCustomer = false;
            }
        });
    }

    ngOnDestroy(): void {
       
    }
}
