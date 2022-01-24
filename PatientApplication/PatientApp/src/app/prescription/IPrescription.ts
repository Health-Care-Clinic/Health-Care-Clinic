
import { IPatient } from "../patient/ipatient";
import { Doctor } from "../registration-form/doctor";
import { IMedicine } from "./IMedicine";

export interface IPrescription {
    medicine : string;
    quantity : number;
    diagnosis: string ;
    date: Date ;
    doctor: Doctor ;
}