import { ModuleWithProviders }  from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { NoFoundPageComponent } from './no-found-page/no-found-page.component';

const appRoutes: Routes = [
  { path: '**', component: NoFoundPageComponent }
];

export const routing: ModuleWithProviders = RouterModule.forRoot(appRoutes);