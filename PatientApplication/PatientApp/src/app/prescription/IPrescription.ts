
import { IPatient } from "../patient/ipatient";
import { Doctor } from "../registration-form/doctor";
import { IMedicine } from "./IMedicine";

export interface IPrescription {
    id: number ;
    medicine : IMedicine;
    comment: string ;
    date: Date ;
    doctor: Doctor ;
}