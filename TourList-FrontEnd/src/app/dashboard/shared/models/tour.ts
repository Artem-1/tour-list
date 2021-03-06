import { Client } from './client';
import { Excursion } from './excursion';
import { ExcursionSight } from './excursion-sight';

export class Tour {
    id?: string;
    date: string;
    client: Client;
    excursion: Excursion;
    snapshotSights: ExcursionSight[];
}