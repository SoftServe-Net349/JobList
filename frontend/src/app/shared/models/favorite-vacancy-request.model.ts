import { User } from "./user.model";
import { Vacancy } from "./vacancy.model";

export interface FavoriteVacancyRequest{
    user: User;
    vacancy: Vacancy;
}