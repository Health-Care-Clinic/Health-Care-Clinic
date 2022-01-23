import { Doctor } from "../registration-form/doctor";

export interface IReport
{
    id : number;
    comment : string;
    date :Date;
    doctor : Doctor;
}