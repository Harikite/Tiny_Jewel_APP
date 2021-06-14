export class customer  {
    username: string = '';
    discount: number = 0.00;
    customerType: string = '';
    constructor(Username: string, Discount: number, CustomerType: string){
        this.username = Username;
        this.discount = Discount;
        this.customerType = CustomerType;
    }
}
