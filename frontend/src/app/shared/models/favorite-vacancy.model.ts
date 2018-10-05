import { Vacancy } from './vacancy.model';

export interface FavoriteVacancy {
  id: number;
  userId: number;
  vacancy: Vacancy;
}
