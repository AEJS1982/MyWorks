import { createAction, props } from '@ngrx/store';

export const doLogin = createAction(
    'Login',
    props<{ username: string; password: string }>()
);

