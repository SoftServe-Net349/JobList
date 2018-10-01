import { Role } from "./role.model";
import {Recruiter} from "./recruiter.model"

export interface Company{
    id: number;
    name: string;
    bossName: string;
    fullDescription: string;
    shortDescription: string;
    address: string;
    phone: string;
    logoData: number[];
    logoMimetype: string;
    site: string;
    email: string;
    password: string;
    role: Role;

    recruiters: Recruiter[];
}