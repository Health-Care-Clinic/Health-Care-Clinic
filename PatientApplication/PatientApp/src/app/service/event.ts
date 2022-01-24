
export class ScheduleEvent {

    id: number = 0
    timestamp: Date = new Date() 
    constructor(private content: string, private userId: number) { }
}