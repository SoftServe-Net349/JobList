import { School } from './school.model';
import { Faculty } from './faculty.model';

export interface EducationPeriod {
  id: number;
  startDate: Date;
  finishDate: Date;
  resumeId: number;
  school: School;
  faculty: Faculty;
}
