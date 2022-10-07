import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';


@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  constructor(private http:HttpClient) { }
  regurl="https://localhost:44372/api/UserAccountModels";
  //regData:UserAccountModel=new UserAccountModel();

  registerUser(userAccountModel:Array<String>)
  {
   return  this.http.post(this.regurl + "/Register",{
    UserName:userAccountModel[0],
    Password:userAccountModel[1],
    PhoneNumber:userAccountModel[2],
    RoleId:userAccountModel[3]

   },
   {
    responseType:'text',
   }

   );
    
}

}