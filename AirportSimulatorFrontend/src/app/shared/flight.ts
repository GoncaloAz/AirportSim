export interface Flight{
    id?: number;
    flightCode: string;
    status:string;
}

export class Flight implements Flight{
    
    id?: number;
    flightCode: string;
    status:string;
    
}