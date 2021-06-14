import { FormControl } from '@angular/forms';

export class CustomValidator {
    static numberValidator(control: FormControl): any {
        if(control.pristine) {
            return null;
        }
        const NUMBER_REGEXP = /^-?[\d.]+(?:e-?\d+)?$/; 
        control.markAsTouched();
        if(NUMBER_REGEXP.test(control.value)){
            return null;
        }
        return {
            invalidNumber: true
        }   
    }
    static noWhiteSpace(control: FormControl) {
        const isInvalid = !((control.value || '').trim().length === 0);
        return isInvalid ? null : { 'whitespace' :true} ;
    }
}