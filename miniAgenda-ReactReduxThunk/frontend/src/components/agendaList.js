import React from 'react';
import { wsProxy } from "../services/wsproxy.js"
import { render } from '@testing-library/react';
import { Link } from 'react-router-dom'
import { BrowserRouter, Route } from "react-router-dom";
import agendaItem from "../components/agendaItem.js"
import { NavLink } from 'react-router-dom';
import 'bootstrap/dist/css/bootstrap.css';
import { connect } from 'react-redux';
import { listContactos, deleteContacto } from "../actions/contactosActions.js"

class agendaList extends React.Component 
{
  deleteContacto(id) {
    alert("Delete item with ID:" + id);

    this.props.deleteContacto(id);
     
  }

  componentDidMount() {
    this.props.listContactos();
    var qs=new URLSearchParams(this.props.location.search)
    this.deleteContacto=this.deleteContacto.bind(this);
  }



  render() {
   return <div><table class="table">
     <tr>
       <td><NavLink className={'bx--btn bx--btn--primary'} to={{pathname:'/agendaItem',search:'?id=0&&op=N'}}>New</NavLink></td>
     </tr>
   </table>
   <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">ID</th>
          <th scope="col">First Name</th>
          <th scope="col">Last Name</th>
          <th scope="col">Year</th>
        </tr>
      </thead>
      <tbody>
      {this.props.contactos.map(item => (
        <tr scope="row">
          <td>{item.ID}</td>
          <td>{item.firstName}</td>
          <td>{item.lastName}</td>
          <td>{item.year}</td>
          <td>
            <NavLink className={'bx--btn bx--btn--primary'} to={{pathname:'/agendaItem',search:'?id=' + item.ID + '&op=E'}}>Edit</NavLink>
          </td>
          <td><NavLink className={'bx--btn bx--btn--primary'} to={{pathname:'/agendaItem',search:'?id=' + item.ID + '&op=D'}}>Delete</NavLink></td>
        </tr>
        ))}
      </tbody>
    </table></div>
  }
}

function mapStateToProps(state) {
  return {contactos: state.contactos}
}

export default connect(mapStateToProps, {listContactos, deleteContacto})(agendaList);

 
