import { Role } from './role.model';

export interface Company {
  id: number;
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
  password: string;
  roleId: number;
}
