import { Client } from './client';
import { Excursion } from './excursion';
import { ExcursionSight } from './excursion-sight';

export class Tour {
    id?: string;
    date: Date;
    client: Client;
    excursion: Excursion;
    excursionSights: ExcursionSight[];
}