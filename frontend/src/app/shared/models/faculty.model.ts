import { School } from "./school.model";

export interface Faculty{
    id: number;
    name: string;
    school: School;
}