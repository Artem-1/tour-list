import { Client } from './client';
import { Excursion } from './excursion';
import { ExcursionSight } from './excursion-sight';

export class Tour {
    id: string;
    date: string;
    clients: Client[];
    excursions: Excursion[];
    excursionSights: ExcursionSight[];
}