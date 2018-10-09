import { City } from './city.model';
import { FavoriteVacancy } from './favorite-vacancy.model';
import { Resume } from './resume.model';

export interface User {
  id: number;
  firstName: string;
  lastName: string;
  phone: string;
  photoData: number[];
  photoMimeType: string;
  sex: string;
  birthData: Date;
  email: string;
  password: string;
  city: City;
  roleId: number;

  favoriteVacancies: FavoriteVacancy[];
}
