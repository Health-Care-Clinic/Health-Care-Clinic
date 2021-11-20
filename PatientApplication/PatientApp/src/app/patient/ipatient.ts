export class Patient {

    firstName: string = "";
    lastName: string = "";
    dateOfBirth: Date = new Date();
    email: string = "";
    username: string = "";
    password: string = "";
    rePassword: string = "";
}

export interface IPatient {
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    email: string;
    username: string;
    password: string;
    rePassword: string;
}
