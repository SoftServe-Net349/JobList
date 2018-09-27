import { WorkArea } from "./work-area.model";
import { User } from "./user.model";

export interface Resume{
    id: number;
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
    workArea: WorkArea;
    user: User;
}