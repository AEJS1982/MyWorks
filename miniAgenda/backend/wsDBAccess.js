//DB Class
const fs = require('fs')


class DBAccess {
	constructor() {
		this.path="contactos.txt";
		this.Contactos=this.loadData(this.path);
	}
	
	
	storeData() {
		try {
			console.log("Storing data");
			fs.writeFileSync(this.path, JSON.stringify(this.Contactos));
		} catch (err) {
			console.error(err);
			console.log("Error storing data");
		}
	}
	
	loadData() {
		try {
			console.log("Loading data from file");
			this.Contactos=JSON.parse(fs.readFileSync(this.path, 'utf8'));
		} catch (err) {
			console.error(err);
			console.log("Error loading data");
			return false;
		}
	}
	
	verificarToken(token) {
		console.log("Entrando de dbAccess.verificarToken() para verificar:" + token.toString());
		var tokenStatus=false;
		
		
		//first Contacto by Token value
		var auxContacto=this.getContactobyToken(token);
		  
		if (auxContacto!=null) {
		  //TODO:Token existe. Verificar vencimiento
		  console.log("Token found. verifying..");
		  var today=new Date();
		  var tokenEndDate=new Date(auxContacto.FechaHoraAltaToken);
		  //tokenEndDate.setHours(tokenEndDate.getHours()+4);
		  tokenEndDate.setMinutes(tokenEndDate.getMinutes()+60);
		  console.log("today:" + today.toISOString());
		  console.log("tokenEndDate:" + tokenEndDate.toISOString());
		  
		  if (today <= tokenEndDate) {
			console.log("Token status OK");
			tokenStatus= true;
		  }
		  else {
			console.log("Token status expired");
			tokenStatus= false;
		  }
		}
		
		return auxContacto;
		
		
		
	}
	
		
	login(nombreUsuario,password,callback) {
		//TODO:
		//Recuperar usuario, Otorgarle un token, guardarlo y setear el token en la DB con su FechaHoraExpiracion
		//Devolver usuario con token
		
		var auxUsuario=getUsuariobyNombre(nombreUsuario);
		
		if (auxUsuario!=undefined) {
			if (auxUsuario.Password==password) {
				callback(auxUsuario);
				
			}
			else
				throw "Usuario/Password invalido!!"; 
			
		}
		else
			throw "Usuario/Password invalido!!"; 
		
		
	}
	
	getContactobyID(ID) {
		if (this.Contactos==null)
			this.loadData();

		console.log("contactos.count=" + this.Contactos.length);
		console.log("ID requested:" + ID);

		try {
			//Math.max.apply(Math, this.Contactos.map(function(o) { return o.ID; }))
			var auxContacto= this.Contactos.find(x => x.ID==ID);
			return auxContacto;
		}
		catch {
			var newContacto = {
		        ID:  0,
		        firstName:    '',
		        lastName: '',
		        year: 0
		    };

			return newContacto;
		}
		
	}
	
	getContactobyNombre(nombre) {
		return this.Contactos.find(x => x.firstName==nombre);
	}
	
	getContactos() {
		console.log("Contactos is null:" + this.Contactos==null);
		
		this.loadData();
		
		if (this.Contactos!=null) {
			if (this.Contactos.length==0)
			{
				console.log("Contactos.count=" + this.Contactos.length);
				var auxP1={ID:1, firstName:"Juan", lastName:"Perez",year:1990};
				var auxP2={ID:2, firstName:"Jose", lastName:"Gomez",year:1991};
				this.agregarContacto(auxP1);
				this.agregarContacto(auxP2);
				this.storeData();
				this.loadData();
			}
		}
	
		console.log("Contactos.count after add=" + this.Contactos.length);
		return this.Contactos;
	}
	
	
	agregarContacto(unaContacto) {
		var newID=Math.max.apply(Math, this.Contactos.map(function(o) { return o.ID; }));
		unaContacto.ID=newID+1;
		console.log("Contacto a agregar:" + unaContacto);
		this.Contactos.push(unaContacto);
		this.storeData();
	}
	
	modificarContacto(unaContacto) {
		//find Contacto by ID
		//modify values
		if (this.Contactos==null) {
			this.loadData();			
		}
		
		console.log("Datos de Contacto recibidos:" + JSON.stringify(unaContacto));
		var auxContacto=this.Contactos.find(x => x.ID==unaContacto.ID);
		console.log("Contacto encontrada:" + JSON.stringify(auxContacto));
		
		if (auxContacto!=null) {
			auxContacto.firstName=unaContacto.firstName;
			auxContacto.lastName=unaContacto.lastName;
			auxContacto.year=unaContacto.year;
			this.storeData();
		}
	}
	
	removerContacto(ID) {
		this.Contactos=this.Contactos.filter(x => x.ID!=ID);
			
		this.storeData();
		this.loadData();
	}
	

	
	generarToken() {
		var min=100000000000;
		var max=999999999999;
		
		return Math.round(Math.random() * (max - min) + min).toString();
		
	}
	
	actualizarToken(usuario) {
		//Token y FechaHoraAltaToken
		
		var d = new Date();
		var fechaAltaToken=d.toISOString();
		
		//TODO:find Contacto , update token and token expiration date
		var auxContacto=getContactobyID(usuario.ID);
		
		if (auxContacto!=null) {
			auxContacto.fechaAltaToken=fechaAltaToken;
		}
	}
	

	
}

// now we export the class, so other modules can create Cat objects
module.exports = {
    DbLayer: DBAccess
}


