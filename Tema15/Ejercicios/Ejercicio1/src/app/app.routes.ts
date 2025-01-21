import { Routes } from '@angular/router';
import {TablaPersonasComponent} from './components/tabla-personas/tabla-personas.component';
import {FormularioPersonaComponent} from './components/formulario-persona/formulario-persona.component';

export const routes: Routes = [
    {path: 'tabla', component: TablaPersonasComponent},
    {path: 'formulario', component: FormularioPersonaComponent}
];
