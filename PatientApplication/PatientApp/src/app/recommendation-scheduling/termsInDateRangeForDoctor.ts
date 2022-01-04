import { DoctorWithSpecialty } from "./doctor-with-specialty";

export interface TermsInDateRangeForDoctor {
    doctor : DoctorWithSpecialty;
    terms : Date[];
}
