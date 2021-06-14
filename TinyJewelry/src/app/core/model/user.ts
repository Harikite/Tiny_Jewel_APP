
export class User {
    username: string; 
    password: string;
    jwtToken: string;

    constructor(username: string, password: string, jwtToken: string) {
        this.username = username;
        this.password = btoa(password);
        this.jwtToken = jwtToken;
    }
    
}
