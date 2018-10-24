import { Vacancy } from './vacancy.model';

export interface Invitation {
  id: number;
  employeeId: number;
  vacancy: Vacancy;
}
