import { Component, OnInit } from '@angular/core';
import { GroceryTable } from 'src/app/models/GroceryTable';
import { GroceryService } from 'src/app/services/grocery.service';

@Component({
  selector: 'app-grocery',
  templateUrl: './grocery.component.html',
  styleUrls: ['./grocery.component.css']
})
export class GroceryComponent implements OnInit {

  constructor(public gservice:GroceryService) { }

  ngOnInit(): void {
    this.gservice.getGroceryCategory().subscribe(x=>{
      this.gservice.grocerycategorylist=x;
    });
  }
  populateGroceryCategory(groceryselected:GroceryTable)
  {
      console.log(groceryselected);
      this.gservice.groceryData=groceryselected;
  }

  deleteGroceryCategory(id:number)
  {
      if(confirm('do you really want to delete ...'))
      {
        this.gservice.deleteGroceryCategory(id).subscribe(x=>
          {
            console.log('deleted');
            this.gservice.getGroceryCategory().subscribe(x=>{
              this.gservice.grocerycategorylist=x;

            });
          },
          error=>{
            console.log('not deleted');
        });
      }
  }

}
