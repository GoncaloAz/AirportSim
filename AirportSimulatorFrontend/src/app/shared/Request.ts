import { Flight } from './flight'

export interface Request{

    id: number;
    flight: Flight;
    total: number;
    type:string;
    time:Date;
    created:Date;
    aproved:boolean;

}