import {Patient} from "../patient/Patient";

export class Address {
  constructor(
    public id?: number,
    public country?: string,
    public state?:  string,
    public city?: string,
    public zipCode?: string,
    public isPrimary?: boolean,
    public patientId?: number,
    public patient?: Patient
  ) {}
}
