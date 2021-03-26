import DateTimeFormat = Intl.DateTimeFormat;
import {Address} from '../address/address';
import {Illness} from '../illness/Illness';


export class Patient {
  constructor(
    public id?: number,
    public name?: string,
    public dayOfBirdth?: DateTimeFormat,
    public email?: string,
    public phoneNumber?: string,
    public addresses?: Address[],
    public illnesses?: Illness[]
  ) {}
}
