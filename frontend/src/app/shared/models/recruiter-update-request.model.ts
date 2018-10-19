
export interface RecruiterUpdateRequest {
  firstName: string;
  lastName: string;
  phone: string;
  email: string;
  photoData: number[];
  photoMimetype: string;
  companyId: number;
  roleId: number;
}
