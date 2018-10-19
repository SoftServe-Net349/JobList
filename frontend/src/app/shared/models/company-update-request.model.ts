
export interface CompanyUpdateRequest {
  name: string;
  bossName: string;
  fullDescription: string;
  shortDescription: string;
  address: string;
  phone: string;
  logoData: number[];
  logoMimetype: string;
  site: string;
  email: string;
  roleId: number;
}
