import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {messageService} from '../../services/messageService';
import { ActivatedRoute } from '@angular/router';
import {wsProxy} from '../../services/wsproxy';
import { ɵBrowserPlatformLocation } from '@angular/common';
import { shoppingListItem } from 'src/app/entities/shoppingListItem';
import { shoppingList } from 'src/app/entities/shoppingList';
import { THIS_EXPR } from '@angular/compiler/src/output/output_ast';

@Component({
  selector: 'app-a-list',
  templateUrl: './a-list.component.html',
  styleUrls: ['./a-list.component.scss']
})
export class aListComponent implements OnInit {
  listData:shoppingList;
  proxy:wsProxy;
  componentRouter:Router;
  showModal:boolean;
  itemName:string;
  itemQuantity:string;

  constructor(private ws:wsProxy,public router: Router,private msgSvc: messageService, private activatedRoute: ActivatedRoute) { 
    var operation=this.activatedRoute.queryParams["value"].Oper;
    this.proxy=ws;
    this.componentRouter=router;
    this.showModal=false;

    switch(operation) {
      case "NEW":
        this.listData=new shoppingList();
        break;
        
      case "EDIT":
        //if this is an edit, find object ID in querystring
        var objID=this.activatedRoute.queryParams["value"].ID;
        this.listData=this.ws.getList(objID);
        
        break;
      
    }
    
  }

  ngOnInit(): void {

  }

  addItem() {
    this.showModal=true;
  }

  deleteItem(ID:number) {
    this.listData.items=this.listData.items.filter(x => x.ID!=ID);
  }

  saveItem() {
    var newItem=new shoppingListItem();
    newItem.itemName=this.itemName;
    newItem.quantity=Number.parseInt(this.itemQuantity);
    this.listData.items.push(newItem);
  }

  hideModal() {
    this.showModal=false;
  }

}
