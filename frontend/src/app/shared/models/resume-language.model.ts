import { Language } from './language.model';
import { Resume } from './resume.model';

export interface ResumeLanguage {
  id: number;
  language: Language;
  resume: Resume;
}
