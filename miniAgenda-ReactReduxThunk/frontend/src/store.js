import { applyMiddleware, createStore } from "redux";
import contactoReducer from "./reducers/contactoReducer.js";
import * as thunk from 'redux-thunk';

const store=createStore(contactoReducer, applyMiddleware(thunk.default));
export default store;