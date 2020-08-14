import { contacto } from "../entities/contacto.js"

export class wsProxy {
    

    constructor() {
      this.list=[];
      this.baseurl="http://localhost:3001/api";
    };

    buildurl(path) {
        return this.baseurl + path;
    }

    async getContacto(id) {
        //Get Contacto via GET

        var url=this.buildurl("/contactos/" + id);
        
        var response=await fetch(url, {
            method: 'GET', // or 'PUT'
            headers:{
            'Content-Type': 'application/json'
            }
        });

        let result=await response.json();
        return result;        

    }

    async deleteContacto(id) {
        //Delete Contacto via GET
        var url=this.buildurl("/contactos/remover/" + id);
        
        var response=await fetch(url, {
            method: 'GET', // or 'PUT'
            headers:{
            'Content-Type': 'application/json'
            }
        });

        let result=await response.json();
        return result;        

    };

    async saveContacto(unaContacto) {
        //Save Contacto via POST
        //debugger;
        var url=this.buildurl("/contactos/nueva");
        
        var response=await fetch(url, {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(unaContacto), // data can be `string` or {object}!
            headers:{
                'Content-Type': 'application/json'
            }
        });

        let result=await response.json();
        return result;        

    };

    async updateContacto(unaContacto) {
        //Update Contacto via POST

        var url=this.buildurl("/contactos/modificar/" + unaContacto.ID);

        var query=await fetch(url, {
            method: 'POST', // or 'PUT'
            body: JSON.stringify(unaContacto), // data can be `string` or {object}!
            headers:{
                'Content-Type': 'application/json'
            }
        });

        let result=await query.json();
        return result;       
    };

    async listContactos() {        //Get contactos via GET
        //debugger;
        var url=this.buildurl("/contactos");
        let query=await fetch(url);
        let response=await query.json();
        return response;
    }

}

