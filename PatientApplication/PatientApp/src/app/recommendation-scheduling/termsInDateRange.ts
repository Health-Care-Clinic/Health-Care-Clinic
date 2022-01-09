import { DoctorWithSpecialty } from "./doctor-with-specialty";
import { TermsInDateRangeForDoctor } from "./termsInDateRangeForDoctor";

export interface TermsInDateRange {
    initiallyPickedDoctor : DoctorWithSpecialty;
    specialty : string;
    beginningDateTime : Date;
    endingDateTime : Date;
    termsInDateRangeForDoctors : TermsInDateRangeForDoctor[];
}
