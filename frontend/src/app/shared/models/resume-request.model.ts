import { User } from "./user.model";


export interface ResumeRequest{
    linkedin: string;
    github: string;
    facebook: string;
    skype: string;
    instagram: string;
    familyState: string;
    softSkills: string;
    keySkills: string;
    courses: string;
    createDate: Date;
    modDate: Date;
    user: User;
}



