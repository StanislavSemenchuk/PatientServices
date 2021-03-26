import {Patient} from '../patient/Patient';

export class Illness {
  constructor(
    public  id?: number,
    public  illName?: string,
    public illType?: illnessType,
    public patients?: Patient[]
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
