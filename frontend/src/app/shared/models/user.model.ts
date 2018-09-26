import { City } from "./city.model";
import { Role } from "./role.model";

export interface User{
    
    id: number;
    firstName: string;
    lastName: string;
    phone: string;
    pphotoData: number[];
    photoMimeType: string;
    sex: string;
    birthData: Date;
    address: string;
    email: string;
    password: string;
    city: City;
    role: Role;
}