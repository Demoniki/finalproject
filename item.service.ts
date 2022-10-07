import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { ItemModel } from '../models/ItemModel';

@Injectable({
  providedIn: 'root'
})
export class ItemService {

  constructor(private http:HttpClient) { }
  
  itemUrl:string='https://localhost:44372/api/ItemModels';
  
  listitems:ItemModel[]=[];
  itemData:ItemModel=new ItemModel();


  getItem():Observable<ItemModel[]>
  {
    return this.http.get<ItemModel[]>(this.itemUrl);
  }

}
