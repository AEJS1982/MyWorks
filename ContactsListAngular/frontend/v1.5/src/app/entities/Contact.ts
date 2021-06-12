export class Contact {
    public id!: number;
    public firstName!: string;
    public lastName!: string;
    public phoneNumber!: number;
    public email!: string;

    constructor(_id:number, _firstName:string, _lastName:string, _phoneNumber:number, _email:string) {
        this.id=_id;
        this.firstName=_firstName;
        this.lastName=_lastName;
        this.phoneNumber=_phoneNumber;
        this.email=_email;
    }

 
}