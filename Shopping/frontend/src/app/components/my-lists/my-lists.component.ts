import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import {messageService} from '../../services/messageService';
import {wsProxy} from '../../services/wsproxy';
import { shoppingList} from "../../entities/shoppingList"


@Component({
  selector: 'app-my-lists',
  templateUrl: './my-lists.component.html',
  styleUrls: ['./my-lists.component.scss']
})
export class MyListsComponent implements OnInit {
  lists:shoppingList[];

  constructor(private ws:wsProxy,public router: Router,private msgSvc: messageService) { 
    this.lists=this.ws.getLists();
    
  }

  ngOnInit(): void {

  }

  
  createNew() {
    var newListName=window.confirm("Enter new list name");
    
  }

  useList(objID:number) {
    this.router.navigate(["/list"],{ queryParams: { ID: objID, Oper :"EDIT"}});
  }

  deleteList(objID:number) {
    this.ws.removeList(objID);
  }
  

}
