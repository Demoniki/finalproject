import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';
import { Order } from '../models/OrderModel';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private http:HttpClient) { }
  ourl:string='https://localhost:44342/api/Orders';
  listorder:Order[]=[];
  orderData:Order=new Order();


  getOrder():Observable<Order[]>
  {
      return this.http.get<Order[]>(this.ourl);
  }
  updateOrder()
  {
    return this.http.put('${this.ourl}/$(this.orderData.orderId)',this.orderData);
  }
  deleteOrder(orderId:number)
  {
    return this.http.delete('$(this.ourl)/$(orderId)');
  }
  saveOrder()
  {
    return this.http.post(this.ourl,this.orderData);
  }

}
