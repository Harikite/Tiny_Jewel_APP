import { Injectable } from '@angular/core';
import { Route } from '@angular/compiler/src/core';
import { Observable } from 'rxjs';
import { map, take } from 'rxjs/operators';
import { AuthService } from './authService';
import { User } from '../model/user';
import { CanActivate, UrlTree } from '@angular/router';
import { CustomerService } from './customerService';
import { Router } from '@angular/router';

@Injectable({
    providedIn: 'root'
})
export class AuthGuard implements CanActivate {
    hasAccess: boolean = false;
  constructor(private authService: AuthService, private router: Router){

    }
    canActivate(): Observable<boolean|UrlTree>| Promise<boolean|UrlTree>|boolean|UrlTree {
       // return false;
      this.authService.UserDetail$.pipe(take(1)).subscribe(data => {
          if (data && data.jwtToken) {
            this.hasAccess =  true;
          } else {
            this.hasAccess =  false;
          } 
      });
      return this.hasAccess;
    }
}
