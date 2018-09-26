import { Resume } from "./resume.model";

export interface ExperienceRequest{
    companyName: string;
    position: string;
    startDate: Date;
    finishDate: Date;
    resume: Resume;
}