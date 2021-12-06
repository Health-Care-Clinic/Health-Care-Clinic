import { IAllergen } from "../patient/allergen";
import { IDoctor } from "../patient/doctor";

export interface IPatient {
    id: number ;
    name: string ;
    surname: string ;
    birthDate: Date ;
    parentName: string ;
    address: string ;
    phone: string ;
    employmentStatus: string ;
    bloodType: string ;
    gender: string ;
    email: string ;
    username: string ;
    password: string ;
    doctorDTO: IDoctor ;
    allergens: IAllergen[] ;
    dateOfRegistration: Date ;
    isBlocked: boolean ;
    isActive: boolean ;
}