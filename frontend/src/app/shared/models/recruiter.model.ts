import { Company } from './company.model';

export interface Recruiter {
  id: number;
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
  photoData: string;
  photoMimetype: string;
  company: Company;
  roleId: number;
}
