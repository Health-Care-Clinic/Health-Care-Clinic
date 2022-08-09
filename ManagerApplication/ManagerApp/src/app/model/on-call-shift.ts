export class OnCallShift {
    id: number;
    doctorId: number;
    date: Date;

    constructor(id: number, doctorId: number, date: Date) {
        this.id = id;
        this.doctorId = doctorId;
        this.date = date;
    }
}
