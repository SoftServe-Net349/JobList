import { School } from "./school.model";
import { Resume } from "./resume.model";

export interface EducationPeriodRequest{
    startDate: Date;
    finishDate: Date;
    resume: Resume;
    school: School;
}