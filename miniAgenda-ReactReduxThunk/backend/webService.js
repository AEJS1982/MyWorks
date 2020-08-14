var http = require('http');
var https = require('https')
var fs = require('fs')
var url = require('url');
var express = require('express');
var cors = require('cors')
var bodyParser = require('body-parser')
//Para checkear los headers se usa req.headers (ahí va el bearer token)
var app = express();
var dbLayer=require('./wsDBAccess.js');
var dbAccess=new dbLayer.DbLayer();
var ipAddress="127.0.0.1";
var app_port=3001;

app.use(express.json());
// Parse URL-encoded bodies (as sent by HTML forms)
app.use(express.urlencoded());
// Parse JSON bodies (as sent by API clients)

//Enable CORS
app.use(cors());

app.use(bodyParser.json());       // to support JSON-encoded bodies
app.use(bodyParser.urlencoded({     // to support URL-encoded bodies
  extended: true
})); 

/*app.use((req,res,next) => {

     res.header("Access-Control-Allow-Origin","*");
     res.header("Access-Control-Allow-Methods", "GET,HEAD,OPTIONS,POST,PUT");
     res.header("Access-Control-Allow-Headers", "Origin, X-Requested-With, Content-Type,Accept,X-Auth-Token, x-client-key, x-client-token, x-client-secret, Authorization");
	 res.header('Allow', 'GET, POST, OPTIONS, PUT, DELETE');
     next();

})*/

var myTokenChecker = function (req, res, next) {
  //Checkear si el token es válido, sino devolver a login
  console.log("Token encontrado:" + req.headers.token);
  console.log("URL solicitada:" + req.url);
  
  if (!req.url.startsWith("/api/login")) {
	  
	  //No va al login, se debe revisar el token
	  var tokenOK=dbAccess.verificarToken(req.headers.token);

	  if (tokenOK!=null) {
		console.log("Token status en myTokenChecker():" + result);
	  
		if (result!=true) {
			res.status(401);
			res.send('Token invalid or expired! Please login');
			//res.end();
		}
		else {
			next();
		}   
		  
	  };
	  
  }
  else {
	//Si es el login pasa de largo
	next();  
  }
  
  
}

//app.use(myTokenChecker);

app.get('/api/test', function(req,res) {
	console.log("Token test generator called");
	res.status(200);
	res.send({ token: dbAccess.generarToken()});
	var token=dbAccess.generarToken();
	res.json({ message: token });
	//res.json({message:"hey"});
});

app.get('/api/contactos', function(req, res) {
	
  //console.log(JSON.stringify(req.headers));
  return res.json(dbAccess.getContactos());
  
});


app.get('/api/contactos/:ID',function(req,res) {
	console.log("Retrieving contacto:" + req.params.ID);
	return res.json(dbAccess.getContactobyID(req.params.ID));
});


app.post('/api/contactos/nueva',function(req,res) {
	console.log("Adding contacto:" + req.body);
	return res.json(dbAccess.agregarContacto(req.body));
});

app.post('/api/contactos/modificar/:ID',function(req,res) {
	console.log("Editing contacto:" + req.params.ID);
	return res.json(dbAccess.modificarContacto(req.body));
});

app.get('/api/contactos/remover/:ID',function(req,res) {
	//console.log("About to delete contacto:" + req.params.ID);
	console.log("Delete contacto:" + req.params.ID);
	return res.json(dbAccess.removerContacto(req.params.ID));
});

app.post('/api/login', function(req, res) {
  var usuario=req.body.usuario;
  var password=req.body.password;
  
  //Obtener usuario (dbAccess.getUsuariobyID)
  //Comparar password 
  //Si dió OK generar token (dbAccess.generarToken) y guardarlo, junto con su validez (dbAccess.actualizarToken)
  //Devolver token
  
  console.log("Login function called!");
  console.log("usuario received:" + usuario);
  console.log("password received:" + password);
  
  var auxUsuario=dbAccess.getUsuariobyNombre(usuario); 
  
  if (auxUsuario!=null) {
	console.log("Object ID from SQL:" + auxUsuario.ID);
	console.log("Errores:" + err);
	//var auxUsuario=JSON.parse(results);
	
		if (auxUsuario!=null) {
			if (auxUsuario.Password==password) {
				console.log("Passwords match and user exists, will generate token");
				auxUsuario.Token=dbAccess.generarToken();
				console.log("Token generated:" + auxUsuario.Token);
				dbAccess.actualizarToken(auxUsuario);
				auxUsuario.Password="****";
				res.json(auxUsuario);
			}
			else
			{
				//res.status(400);
				res.send("Error! User/Password incorrect.");
			}
		}
		else
		{
			//res.status(400);
			res.send("Error! User/Password incorrect.");
		}
  
	}
});



app.listen(app_port, function() {
  console.log('Agenda webService, listening in port:' + app_port);
});



/*https.createServer({
  key: fs.readFileSync('localhost.key'),
  cert: fs.readFileSync('localhost.cert')
}, app)
	.listen(3000, ipAddress, () => 
		{
			console.log('Agenda webService, escuchando en el puerto 3000!')
		}
	);
*/