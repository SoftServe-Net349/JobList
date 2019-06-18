import { City } from './city.model';
import { Role } from './role.model';

export interface Employee {
  id: number;
  firstName: string;
  lastName: string;
  phone: string;
  photoData: string;
  photoMimeType: string;
  sex: string;
  birthDate: Date;
  email: string;
  city: City;
  role: Role;
}
