import { wsProxy } from "../services/wsproxy.js"
import { contacto } from "../entities/contacto.js"
import axios from 'axios';

export function getbaseURL() {
  let baseurl="http://localhost:3001/api";
  return baseurl;
}

export function fetchContacto(id) {
  var x=new wsProxy();

  return async dispatch => {
    function onSuccess(success) {
      dispatch({ type: "FETCH_CONTACTO", payload: success.data });
      return success;
    }

    function onError(error) {
      dispatch({ type: "FETCH_CONTACTO", error });
      return error;
    }
    
    try {
      const success = await axios.get(getbaseURL() + "/contactos/" + id);
      return onSuccess(success);
    } catch (error) {
      return onError(error);
    }
  }
}

export function newContacto() {
    return dispatch => {
      dispatch({
        type: 'NEW_CONTACTO'
      })
    }
}

export function saveContacto(CONTACTO) {

  return async dispatch => {
    function onSuccess(success) {
      dispatch({ type: "SAVE_CONTACTO", payload: success.data });
      return success;
    }

    function onError(error) {
      dispatch({ type: "SAVE_CONTACTO", error });
      return error;
    }
    
    try {
      const success = await axios.post(getbaseURL() + "/contactos/nueva",CONTACTO);
      return onSuccess(success);
    } catch (error) {
      return onError(error);
    }
  }


}

export function updateContacto(unContacto) {

  return async dispatch => {
    function onSuccess(success) {
      dispatch({ type: "DELETE_CONTACTO", payload: success.data });
      return success;
    }

    function onError(error) {
      dispatch({ type: "DELETE_CONTACTO", error });
      return error;
    }
    
    try {
      const success = await axios.post(getbaseURL() + "/contactos/modificar/" + unContacto.ID,unContacto);
      return onSuccess(success);
    } catch (error) {
      return onError(error);
    }
  }


}

export function deleteContacto(id) {

  return async dispatch => {
    function onSuccess(success) {
      dispatch({ type: "DELETE_CONTACTO", payload: success.data });
      return success;
    }

    function onError(error) {
      dispatch({ type: "DELETE_CONTACTO", error });
      return error;
    }
    
    try {
      const success = await axios.get(getbaseURL() + "/contactos/remover/" + id);
      return onSuccess(success);
    } catch (error) {
      return onError(error);
    }
  }

}


export function listContactos() {

  return async dispatch => {
    function onSuccess(success) {
      dispatch({ type: "LIST_CONTACTOS", payload: success });
      return success;
    }

    function onError(error) {
      dispatch({ type: "LIST_CONTACTOS", error });
      return error;
    }
    
    try {
      const success = await axios.get(getbaseURL() + "/contactos");
      return onSuccess(success);
    } catch (error) {
      return onError(error);
    }
  }
 
}



