import { combineReducers, createStore } from 'redux'
import { personasReducer } from "./personaReducer.js"


const reducers = {
    personasStore:personasReducer
}
  
const rootReducer = combineReducers(reducers);

export default rootReducer;