import { City } from './city.model';
import { Recruiter } from './recruiter.model';
import { WorkArea } from './work-area.model';

export interface VacancyRequest {
  name: string;
  description: string;
  offering: string;
  requirements: string;
  bePlus: string;
  isChecked: string;
  salary: number;
  fullPartTime: string;
  createDate: Date;
  modDate: Date;
  city: City;
  recruiter: Recruiter;
  workArea: WorkArea;
}
