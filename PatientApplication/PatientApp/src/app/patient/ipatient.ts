import { Allergen } from "../registration-form/allergen";
import { Doctor } from "../registration-form/doctor";

export class Patient {
    id: number = 0;
    name: string = "";
    surname: string = "";
    birthDate: Date = new Date();
    parentName: string = "";
    address: string = "";
    phone: string = "";
    employmentStatus: string = "";
    bloodType: string = "";
    gender: string = "";
    email: string = "";
    username: string = "";
    password: string = "";
    doctorDTO: Doctor = {id: 0, name: "", surname: ""};
    alergies: Allergen[] = [];
    dateOfRegistration: Date = new Date();
    isBlocked: boolean = false;
    isActive: boolean = false;
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
    doctor: number;
    allergens: number[];
}
