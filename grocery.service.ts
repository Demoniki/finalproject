import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { GroceryTable } from '../models/GroceryTable';

@Injectable({
  providedIn: 'root'
})
export class GroceryService {

  
  constructor(private http:HttpClient) { }

  gurl:string="https://localhost:44372/api/GroceryTables";
  grocerycategorylist:GroceryTable[]=[];
  groceryData:GroceryTable=new GroceryTable();

  getGroceryCategory():Observable<GroceryTable[]>
  {
      return this.http.get<GroceryTable[]>(this.gurl);
  }
  updateGroceryCategory()
  {
    return this.http.put(`${this.gurl}/$(this.groceryData.GroceryId)`,this.groceryData);
  }
  deleteGroceryCategory(groceryId:number)
  {
    return this.http.delete(`${this.gurl}/${groceryId}`);
  }
}
