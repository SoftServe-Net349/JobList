import { Resume } from './resume.model';

export interface Experience {
  id: number;
  companyName: string;
  position: string;
  startDate: Date;
  finishDate: Date;
  resume: Resume;
}
