import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginModel } from '../models/LoginModel';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  url="https://localhost:44372/api/UserAccountModels";
  loginList:LoginModel[]=[];
  data:LoginModel=new LoginModel();

  constructor(private http:HttpClient) { }

  loginMethod(){
    return this.http.post(this.url+"/Login",this.data)
  }

}
