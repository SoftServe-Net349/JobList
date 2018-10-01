import { School } from "./school.model";
import { Resume } from "./resume.model";

export interface EducationPeriod{
    id: number
    startDate: Date;
    finishDate: Date;
    resume: Resume;
    school: School;
}