import { User } from './user.model';
import { Vacancy } from './vacancy.model';

export interface FavoriteVacancy {
  id: number;
  user: User;
  vacancy: Vacancy;
}
