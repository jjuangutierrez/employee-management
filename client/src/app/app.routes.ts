import { Routes } from '@angular/router';
import { MainLayout } from './core/layout/main-layout/main-layout';
import { Account } from './features/account/profile';
import { Login } from './features/auth/login/login';
import { Notifications } from './features/notifications/notifications';
import { Tasks } from './features/tasks/tasks';

export const routes: Routes = [
  {
    path: '',
    component: MainLayout,
    children: [
      { path: '', redirectTo: 'profile', pathMatch: 'full' },
      { path: 'profile', component: Account },
      { path: 'tasks', component: Tasks },
      { path: 'notifications', component: Notifications },
    ],
  },
  { path: 'login', component: Login },
  { path: '**', redirectTo: '' },
];
