import { Company } from './company.model';
import { Role } from './role.model';
import { Vacancy } from './vacancy.model';

export interface Recruiter {
  id: number;
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
  password: string;
  company: Company;
  roleId: number;

  vacancy: Vacancy[];
}
