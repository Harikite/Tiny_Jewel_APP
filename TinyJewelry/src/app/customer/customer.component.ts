import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormBuilder, Validators, FormControl } from '@angular/forms';
import { CustomerService } from '../core/services/customerService';
import { take } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { InformationComponent } from '../core/component/information.component';
import * as pdfMake from 'pdfmake/build/pdfmake';
import * as pdfFonts from 'pdfmake/build/vfs_fonts';
import { AuthService } from '../core/services/authService';

@Component({
  selector: 'tiny-jewel-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit, OnDestroy {
 
  productForm = this.formBuilder.group({
    goldPrice: new FormControl('',Validators.required),
    weight: new FormControl('', Validators.required),
    discount: new FormControl({value:0,disabled:true}),
    totalPrice: new FormControl({value:'',disabled:true})
  });
  isNormalCustomer: boolean = false;

  
  constructor(private formBuilder: FormBuilder, private authService: AuthService,
    private customerService: CustomerService, private dialog: MatDialog) { 
      // pdfMake.vfs = pdfFonts.pdfMake.vfs;
    }

  ngOnInit(): void {
   
     this.authService.UserDetail$.pipe(take(1)).subscribe( user => {
      if (user) {
        this.customerService.GetCustomerDetails(user.username,user.jwtToken).subscribe(data => {
          if (data) {
            this.customerService.SetCustomerDetails(data);
            this.productForm.patchValue({
              discount: data.discount
            });
            if (data.customerType === "1") {
              this.isNormalCustomer =  true;
            }
          } 
        });
      }
     });
  }

  Calculate() {
    this.productForm.markAllAsTouched();
    if(this.productForm.valid){
      const product = this.productForm.value;
      const discount = Number(product.discount) > 0 ? (Number(product.discount) / 100) : 0 ;
      const price = (Number(product.goldPrice) * Number(product.weight));  
      const totalPrice = price - (price*discount);
      this.productForm.patchValue({
        totalPrice: totalPrice
      });
    }
  }

  DisplayPrice() {
     const info = this.GetContent();
    this.dialog.open(InformationComponent,{
      data: info,
      panelClass: 'dialogClass'
    });
  }

  GetContent(): string {
    this.productForm.markAllAsTouched();
    const product =  this.productForm.getRawValue();
    const info = "Gold Price (Per Gram) = " + product.goldPrice  + "<br/>" +
                 "Weights (Gram) =  " + product.weight  + "<br/>" +
                 (this.isNormalCustomer ? "" : "Discount = " + (isNaN(product.discount) ? '' : (product.discount + " % " )) + " <br/>") +
                 "Total Price = " + ( isNaN(product.totalPrice) ? '' : product.totalPrice)  + "<br/>" ;   
    
    return info;
  }

  DisplayPDF() {
   const data = this.GetContent().replace(/<br\/>/gi,'\n');
   const docDefinition = {
     content: data
   };
   pdfMake.createPdf(docDefinition,{},
    {
      // Default font should still be available
      Roboto: {
        normal: 'Roboto-Regular.ttf',
        bold: 'Roboto-Medium.ttf',
        italics: 'Roboto-Italic.ttf',
        bolditalics: 'Roboto-Italic.ttf'
      },
      // Make sure you define all 4 components - normal, bold, italics, bolditalics - (even if they all point to the same font file)
      TimesNewRoman: {
        normal: 'Times-New-Roman-Regular.ttf',
        bold: 'Times-New-Roman-Bold.ttf',
        italics: 'Times-New-Roman-Italics.ttf',
        bolditalics: 'Times-New-Roman-Italics.ttf'
      }
    },
    pdfFonts.pdfMake.vfs).open();
  }

  DisplayPaper() {
    this.dialog.open(InformationComponent,{
      data: "Printer is not available for time being.!!!",
      panelClass: 'dialogClass'
    });
  }

  ngOnDestroy(): void {
    
  }

}
