import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { Injectable } from '@angular/core';
import { shoppingListItem } from "../entities/shoppingListItem";
import { shoppingList } from '../entities/shoppingList';
import { applySourceSpanToExpressionIfNeeded } from '@angular/compiler/src/output/output_ast';

@Injectable({
  providedIn: 'root'
})
export class wsProxy {
  listCache:shoppingList[];

  private webServiceURL = 'http://localhost:3000/api/';
  //private webServiceURL=environment.myEndpoint;
  constructor(private http: HttpClient, public router: Router) {
    //debugger;
    this.listCache=[];
  }

  getList(ID:number) {
    //Fill this
    var aList=this.listCache.find(x => x.listID==ID);
    return aList;    
  }

  loadData() {
    if (!localStorage.getItem("SuperMarketLists")) {
      this.generateInitialData();
      localStorage.setItem("SuperMarketLists",JSON.stringify(this.listCache));
    }
    else {
      this.listCache=JSON.parse(localStorage.getItem("SuperMarketLists"));
    }
  }

  generateInitialData() {

    var aList1=new shoppingList();
    aList1.name="SuperMarket";
    aList1.listID=1;
    aList1.dateCreated=new Date(Date.now()).toJSON().slice(0,10);
    
    var breadItem=new shoppingListItem();
    breadItem.itemName="Bread";
    breadItem.quantity=4;
    breadItem.price=10;
    breadItem.bought=false;

    var saltItem=new shoppingListItem();
    saltItem.itemName="Salt";
    saltItem.quantity=1;
    saltItem.price=20;
    saltItem.bought=false;

    aList1.items.push(breadItem);
    aList1.items.push(saltItem);

    var aList2=new shoppingList();
    aList2.listID=2;
    aList2.name="GroceryStore";
    aList2.dateCreated=new Date(Date.now()).toJSON().slice(0,10);

    var appleItem=new shoppingListItem();
    appleItem.itemName="Apples";
    appleItem.quantity=10;
    appleItem.price=4;
    appleItem.bought=false;

    var orangesItem=new shoppingListItem();
    orangesItem.itemName="Oranges";
    orangesItem.quantity=12;
    orangesItem.price=6;

    aList2.items.push(appleItem);
    aList2.items.push(orangesItem);

    //debugger;
    this.listCache.push(aList1);
    this.listCache.push(aList2);
  }
 
  getLists(): shoppingList[] {
    //debugger;
    if (this.listCache==null || this.listCache.length==0)
      this.loadData();

    return this.listCache;
  }

  addList(newItem: shoppingList) {
    //TODO:Complete this
    this.listCache=this.getLists();
    this.listCache.push(newItem);
    sessionStorage.setItem("SuperMarketLists",JSON.stringify(this.listCache));
  }

  removeList(ID: number) {
    //TODO:Complete this
    this.listCache=this.listCache.filter(x => x.listID!=ID);
    sessionStorage.setItem("SuperMarketLists",JSON.stringify(this.listCache));
  }
}
