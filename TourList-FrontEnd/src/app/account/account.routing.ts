import { ModuleWithProviders } from '@angular/core';
import { RouterModule }        from '@angular/router';

import { RegistrationFormComponent }    from './registration-form/registration-form.component';
import { LoginFormComponent }    from './login-form/login-form.component';
import { ReAuthGuard } from '../re-auth.guard';

export const routing: ModuleWithProviders = RouterModule.forChild([
  { path: 'reg', component: RegistrationFormComponent, canActivate: [ReAuthGuard] },
  { path: '', component: LoginFormComponent, canActivate: [ReAuthGuard] }
]);