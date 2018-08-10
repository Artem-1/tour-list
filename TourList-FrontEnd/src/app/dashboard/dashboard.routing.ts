import { ModuleWithProviders } from '@angular/core';
import { RouterModule }        from '@angular/router';

import { AuthGuard } from '../auth.guard';
import { RootComponent } from './root/root.component';
import { TourListComponent } from './tour-list/tour-list.component';

export const routing: ModuleWithProviders = RouterModule.forChild([
    { path: '', component: RootComponent, canActivate: [AuthGuard],
        children: [
            { path: 'tours', component: TourListComponent }
        ]
    },
]);