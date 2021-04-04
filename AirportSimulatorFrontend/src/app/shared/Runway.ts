
export interface Runway{
    id?: number;
    flightOnRunway: string;
    available:boolean;
}

export class Runway implements Runway{
    
    id?: number;
    flightOnRunway: string;
    available:boolean;
    
}