import { RolesModel } from "./RolesModel";

export class UserAccountModel{

    userId:number;
    userName:String;
    password:String;
    phoneNumber:String;
    roleId: number;
    roleModel:RolesModel;


}