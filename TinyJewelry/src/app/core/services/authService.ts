import { Observable, BehaviorSubject } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http'
import { User } from 'src/app/core/model/user';

@Injectable({
    providedIn: 'root'
})
export class AuthService{
    private baseUrl: string = 'http://localhost:5000/Auth/RequestToken';

    private userDetail = new BehaviorSubject<User>(new User('','',''));
    UserDetail$ = this.userDetail.asObservable();

    constructor(private http: HttpClient) {

    }

    ValidateUser(userObj: User): Observable<any> {
        const httpOptions = {
            headers: new HttpHeaders({
                'Content-Type': 'application/json',
                'Authorization' : 'Basic ' + userObj.username + ":" + userObj.password 
            })
        };
        return this.http.post<any>(this.baseUrl, userObj , httpOptions);
    }

    setUserDetail(token: User) {
        this.userDetail.next(token);
    }

}
