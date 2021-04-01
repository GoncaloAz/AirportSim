export interface Request{

    id: number;
    flightCode: string;
    requestType:string;
    timeForRequest:Date;
    timeOfRequestCreation:Date;
    aproved:boolean;

}