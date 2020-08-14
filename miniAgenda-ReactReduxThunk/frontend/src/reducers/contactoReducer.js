import { contacto } from "../entities/contacto.js"

const defaultState = {
    contactos: [],
    unContacto:new contacto(),
    loading: false,
    errors:{}
  }

const contactosReducer= (state=defaultState, action={}) => {
  //debugger;

  switch (action.type) {
    case "FETCH_CONTACTO_REQUESTED":
      //debugger;
      var auxContacto=new contacto(0,"","",0);
      return { ...state, unContacto: auxContacto};

    case "FETCH_CONTACTO_FAILED":
      //debugger;
      var auxContacto=new contacto(0,"","",0);
      return { ...state, unContacto: auxContacto };


    case "FETCH_CONTACTO": 
      // debugger;
      var auxContacto=action.payload;
      return { ...state, unContacto: auxContacto };

    case "NEW_CONTACTO":
      let index = state.findIndex(c => c.id == action.data.id)
      if (index === -1) {
          return [...state, action.data]
      }
      return state;
      

    case "SAVE_CONTACTO":
      debugger;
      return state;
      
    case "UPDATE_CONTACTO":
      debugger;
      return state.map(c => c.id === action.id ? 
      { ...c, firstname: action.firstname, 
        lastname:action.lastname,year:action.year 
      } : contacto);
     

    case "DELETE_CONTACTO":
      return { contactos : state.contactos.filter(c => c.id !== action.id) }
     
    case "LIST_CONTACTOS_REQUESTED":
      return state;

    case "LIST_CONTACTOS_FAILED":
      return state;
 
    case "LIST_CONTACTOS":
      return { ...state, contactos: action.payload.data };
    
    default:
      return state;
   
  }
}

export default contactosReducer;
