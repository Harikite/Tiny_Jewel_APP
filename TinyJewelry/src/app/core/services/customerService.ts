import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import { customer } from '../model/customer';

@Injectable({
    providedIn: 'root'
})
export class CustomerService {

    baseUrl: string = "http://localhost:5000/Customer"
    constructor(private http: HttpClient) {

    }

    private customerDetails = new BehaviorSubject<customer>(new customer('', 0,''));
    customerDetails$ = this.customerDetails.asObservable();

    SetCustomerDetails(cust: customer){
        this.customerDetails.next(cust);
    }

    GetCustomerDetails(customerId: string,token: string): Observable<customer> {
        const serviceUrl = this.baseUrl + "/GetCustomer/" + customerId;
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization' : 'Bearer ' + token
            })
        };
        return this.http.get<customer>(serviceUrl, httpOptions);
    }
}