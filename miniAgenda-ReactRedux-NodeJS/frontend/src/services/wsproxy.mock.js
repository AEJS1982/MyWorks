import { contacto } from "../entities/contacto.js"

export class wsProxy {
    

    constructor() {
      this.list=[];
    };

    fetchContacto(id) {
      var auxP=this.list.find(x => x.id==id);

      if (auxP!=null) 
        return auxP;
    }

    deleteContacto(id) {
      this.list=this.list.filter(x => x.id!=id);
    };

    saveContacto(unaContacto) {
      this.list.push(unaContacto);
    };

    updateContacto(unaContacto) {
      //var auxP=this.list.find(x => x.id==unaContacto.id);
      this.deleteContacto(unaContacto.id);
      this.saveContacto(unaContacto);
    };

    listContactos() {
      //debugger;
      if (this.list.length==0) {
        var auxP1=new contacto();
        auxP1.id="1";
        auxP1.firstname="Robin";
        auxP1.lastname="Wieruch";
        auxP1.year=1988;
        this.list.push(auxP1);
        var auxP2=new contacto();
        auxP2.id="2";
        auxP2.firstname="Dave";
        auxP2.lastname="Davidds";
        auxP2.year=1990;

        this.list.push(auxP2);
      }
         
      return this.list;

    }
}

