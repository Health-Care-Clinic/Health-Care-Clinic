
export class ScheduleEvent {

    id: number = 0
    timestamp: Date = new Date()
    constructor(public content: string, public userId: number) { }
}

export interface EventSession {
    id: number
    events: ScheduleEvent[]
    resultedInSucces: boolean
    userId: number
}