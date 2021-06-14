import { Component, Inject } from "@angular/core";
import {MatDialogRef, MAT_DIALOG_DATA} from "@angular/material/dialog";

@Component({
    selector: 'tiny-jewel-info',
    templateUrl: './information.component.html',
    styleUrls: ['./information.component.scss']
})
export class InformationComponent {
    message: string = '';
    constructor(public dialogRef: MatDialogRef<InformationComponent>, 
        @Inject(MAT_DIALOG_DATA) public data: string){

        }
    OnClick(){
        this.dialogRef.close(true);
    }
}