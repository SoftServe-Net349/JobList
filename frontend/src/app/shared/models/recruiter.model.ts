import { Company } from './company.model';

export interface Recruiter {
  id: number;
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
  photoData: number[];
  photoMimetype: string;
  company: Company;
  roleId: number;
}
