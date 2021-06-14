import { NgModule } from "@angular/core";
import {MatInputModule } from '@angular/material/input';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatToolbarModule }from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatDialogModule } from '@angular/material/dialog';
@NgModule({
declarations: [],
imports: [
 MatInputModule,
 MatGridListModule,
 MatToolbarModule,
 MatIconModule,
 MatButtonModule,
 MatDialogModule  
],
exports: [
    MatInputModule,
    MatGridListModule,
    MatToolbarModule ,
    MatIconModule,
    MatButtonModule,
    MatDialogModule 
]
})

export class MaterialModule{

}