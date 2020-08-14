import React, { Fragment } from "react";
import "./index.css"
import { BrowserRouter, Route } from "react-router-dom";
import agendaList  from "./components/agendaList";
import agendaItem from "./components/agendaItem.js"
import wsProxy from "./services/wsproxy"
import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.css';
import 'bootstrap/dist/js/bootstrap.js';
import $ from 'jquery';
import Popper from 'popper.js';
import { NavLink } from 'react-router-dom';
import { Provider } from 'react-redux';
import store from "./store"

export default function App() {
  return (
  
    <BrowserRouter>
      <Provider store={store}>
      <nav class="navbar navbar-expand-lg navbar-light bg-light">
        <a class="navbar-brand" href="#">Mini Agenda</a>
        <button class="navbar-toggler" type="button" data-toggle="collapse" data-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
          <span class="navbar-toggler-icon"></span>
        </button>

        <div class="collapse navbar-collapse" id="navbarSupportedContent">
          <ul class="navbar-nav mr-auto">
            <li class="nav-item active">
              <a class="nav-link" href="#">Home <span class="sr-only">(current)</span></a>
            </li>
            <li class="nav-item dropdown">
              <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                Menu
              </a>
              <div class="dropdown-menu" aria-labelledby="navbarDropdown">
                <NavLink className={'dropdown-item'} to={{pathname:'/agenda'}}>Listado</NavLink>
                <NavLink className={'dropdown-item'} to={{pathname:'/agendaItem',search:'?id=0&op=N'}}>Nuevo item</NavLink>
              </div>
            </li>

          </ul>
          <form class="form-inline my-2 my-lg-0">
            <input class="form-control mr-sm-2" type="search" placeholder="Search" aria-label="Search"/>
            <button class="btn btn-outline-success my-2 my-sm-0" type="submit">Search</button>
          </form>
        </div>
      </nav>
      <Route path = "home" component = {Home} />
      <Route path = "/agenda" component = {agendaList} />
      <Route path = "/agendaItem" component = {agendaItem} />
      </Provider>
    </BrowserRouter>
  
  );
}

const Home = () => (
  <Fragment>
    <h1>Home</h1>
  </Fragment>
);
