import {Patient} from '../patient/Patient';

export class Illness {
  constructor(
    public  id?: number,
    public  illName?: string,
    public illType?: illnessType,
    public patients?: Array<Patient>
  ) {}
}

enum illnessType {
  Allergies,
  ColdOrFlu,
  Conjunctivitis,
  Diarrhea,
  Headaches,
  Mononucleosis,
  StomachAches,
  Virus
}
