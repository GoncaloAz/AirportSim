import { Flight } from './Flight'

export interface Request{

    id?: number;
    flight: Flight;
    total: number;
    type:string;
    time:Date;
    created:Date;
    aproved:boolean;

}

export class Request implements Request{

    id?: number;
    flight: Flight;
    total: number;
    type:string;
    time:Date;
    created:Date;
    aproved:boolean;

}