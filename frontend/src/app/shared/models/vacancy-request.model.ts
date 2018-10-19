
export interface VacancyRequest {
  name: string;
  description: string;
  offering: string;
  requirements: string;
  bePlus: string;
  isChecked?: boolean;
  salary?: number;
  fullPartTime: string;
  createDate: Date;
  cityId: number;
  recruiterId: number;
  workAreaId: number;
}
