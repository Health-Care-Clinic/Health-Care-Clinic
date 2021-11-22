export class Patient {

    firstName: string = "";
    lastName: string = "";
    dateOfBirth: Date = new Date();
    nameOfParent: string = "";
    address: string = "";
    phoneNumber: string = "";
    employmentStatus: string = "";
    bloodType: string = "";
    gender: string = "";
    email: string = "";
    username: string = "";
    password: string = "";
    rePassword: string = "";
    doctor: string = "";
    allergies: string[] = [];
}

export interface IPatient {
    firstName: string;
    lastName: string;
    dateOfBirth: Date;
    nameOfParent: string;
    address: string;
    phoneNumber: string;
    employmentStatus: string;
    bloodType: string;
    gender: string;
    email: string;
    username: string;
    password: string;
    rePassword: string;
    doctor: string;
    allergies: string[];
}
