export class contacto {


    constructor(id, firstname,lastname,year) {
        this.ID=id;
        this.firstName=firstname;
        this.lastName=lastname;
        this.year=year;
    }

    setID(ID) {
        this.ID=ID;
    }

    getFistName() {
        return this.firstName;
    }

    setFirstName(name) {
        this.firstName=name;        
    }

    getLastName() {
        return this.lastName;
    }

    setLastName(name){
        this.lastName=name;        
    }

    getYear() {
        return this.year;
    }

    setYear(year) {
        this.year=year;        
    }
}