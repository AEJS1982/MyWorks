import React from 'react';
import { wsProxy } from "../services/wsproxy.js"
import queryString from 'query-string';
import { contacto } from "../entities/contacto"
import { connect } from 'react-redux';
import { newContacto, saveContacto, fetchContacto, updateContacto,deleteContacto} from "../actions/contactosActions.js"

class agendaItem extends React.Component
{
    constructor(props) {
        super(props);

        this.saveContacto=this.saveContacto.bind(this);
        this.handlefirstNameChange=this.handlefirstNameChange.bind(this);
        this.handleLastNameChange=this.handleLastNameChange.bind(this);
        this.handleYearChange=this.handleYearChange.bind(this);
    }

    handlefirstNameChange(e) {
        //Prevent bad characters from being inputted
        e.target.value = e.target.value.replace(/[^a-zA-Z0-9_-]/g,'');
    }

    //handleLastNameChange
    handleLastNameChange(e) {
        //Prevent bad characters from being inputted
        e.target.value = e.target.value.replace(/[^a-zA-Z0-9_-]/g,'');
    }

    handleYearChange(e) {
        //Prevent bad characters from being inputted
        e.target.value = e.target.value.replace(/[^0-9]/g,'');
    }


    saveContacto(event) 
    {
        //debugger;
        event.preventDefault();
         
        var qs=new URLSearchParams(event.target.action);

        var auxContacto=new contacto();
        auxContacto.setFirstName(event.target.txtName.value);
        auxContacto.setLastName(event.target.txtLastName.value);
        auxContacto.setYear(event.target.txtYear.value);

        if (qs.get("op")=="N") {
            this.props.saveContacto(auxContacto);
        }
        
        if (qs.get("op")=="E") {
            auxContacto.setID(event.target.txtID.value);
            this.props.updateContacto(auxContacto);
         
        }

        window.location="/Listado";
    }

    cancelSave() {
        window.location="/Listado";
    }

    componentWillReceiveProps(newprops) {
        console.log("new data received!");        
        debugger;
        this.props.contacto.ID=newprops.contacto.ID;
        this.props.contacto.firstName=newprops.contacto.firstName;
        this.props.contacto.lastName=newprops.contacto.lastName;
        this.props.contacto.year=newprops.contacto.year;
    }

    componentWillMount() {

        var qs=new URLSearchParams(this.props.location.search)
        var searchId=qs.get("id");

        switch(qs.get("op")) {
            case "N":    
                this.props.contacto.ID=0;
                this.props.contacto.firstName="";
                this.props.contacto.lastName="";
                this.props.contacto.year=0;

                break;

            case "E":
                this.props.fetchContacto(searchId).then((resp)=>{
                    console.log("Contacto read! Please go to Listado");
                });
    
                break;

            case "D":
                this.props.deleteContacto(searchId).then(()=>{
                    console.log("Contacto deleted! Please go to Listado")
                });
    
                break;
        }

    }

    render() {
        return (
            <form onSubmit={this.saveContacto}>
                <table class="table table-striped"> 
                    <tbody>
                        <tr scope="row">
                            <td>ID</td>
                            <td><input type="number" name="txtID" defaultValue={this.props.contacto.ID} Value={this.props.contacto.ID} enabled="false"></input></td>
                        </tr>

                        <tr scope="row">
                            <td>First Name</td>
                            <td><input type="text" name="txtName" defaultValue={this.props.contacto.firstName} Value={this.props.contacto.firstName} onChange={this.handlefirstNameChange}></input></td>
                        </tr>

                        <tr scope="row">
                            <td>Last Name</td>
                            <td><input type="text" name="txtLastName" defaultValue={this.props.contacto.lastName} Value={this.props.contacto.lastName} onChange={this.handleLastNameChange}></input></td>
                            
                        </tr>

                        <tr scope="row">
                            <td>Year</td>
                            <td><input type="number" name="txtYear" defaultValue={this.props.contacto.year} Value={this.props.contacto.year}></input></td>
                        </tr>                        
                        
                        <tr scope="row">
                            <td><input type="submit" value="Save"/></td>
                            <td><input type="button" value="Cancel" onClick={this.CancelSave}/></td>
                        </tr>
                    </tbody>
                </table>
            </form>)
    }
}

function mapStateToProps(state) {
    //debugger;
    return {
      contacto: state.unContacto,
      errors: state.errors
    }
}
  
  export default connect(mapStateToProps, {newContacto, saveContacto, fetchContacto, deleteContacto, updateContacto})(agendaItem);
