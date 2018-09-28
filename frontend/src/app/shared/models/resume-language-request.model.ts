import { Language } from "./language.model";
import { Resume } from "./resume.model";

export interface ResumeLanguageRequest{
    language: Language;
    resume: Resume;
}