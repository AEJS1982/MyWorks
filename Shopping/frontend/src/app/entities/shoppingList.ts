import { shoppingListItem } from "./shoppingListItem";

export class shoppingList {
    listID:number;
    name:string;
    dateCreated:string;
    description:string;
    items:shoppingListItem[];

    constructor() {
        this.items=[];        
    }
}