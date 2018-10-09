import { City } from './city.model';
import { Role } from './role.model';
import { Resume } from './resume.model';

export interface UserRequest {
  firstName: string;
  lastName: string;
  phone: string;
  photoData: number[];
  photoMimeType: string;
  sex: string;
  birthData: Date;
  email: string;
  password: string;
  cityId: number;
  roleId: number;
}
