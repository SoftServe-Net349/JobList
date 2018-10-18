import { WorkArea } from './work-area.model';
import { Employee } from './employee.model';
import { Experience } from './experience.model';
import { EducationPeriod } from './education-period.model';
import { ResumeLanguage} from './resume-language.model';

export interface Resume {
  id: number;
  linkedin: string;
  github: string;
  facebook: string;
  skype: string;
  instagram: string;
  familyState: string;
  softSkills: string;
  keySkills: string;
  position: string;
  introduction: string;
  courses: string;
  createDate: Date;
  modDate: Date;
  workArea: WorkArea;
  employee: Employee;

  educationPeriods: EducationPeriod[];
  experiences: Experience[];
  resumeLanguages: ResumeLanguage[];
}
