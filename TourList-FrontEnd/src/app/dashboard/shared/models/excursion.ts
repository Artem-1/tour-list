import { Tour } from './tour';
import { ExcursionSight } from './excursion-sight';

export class Excursion {
  id?: string;
  name: string;
  excursionSights: ExcursionSight[];
}