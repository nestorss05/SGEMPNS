import { Routes } from '@angular/router';

import {TablaPersonasComponent} from './components/tabla-personas/tabla-personas.component';
import {FormularioPersonaComponent} from './components/formulario-persona/formulario-persona.component';
import {FormularioReactivoComponent} from './components/formulario-reactivo/formulario-reactivo.component';

export const routes: Routes = [
    {path: 'tabla', component: TablaPersonasComponent},
    {path: 'formulario', component: FormularioPersonaComponent},
    {path: 'reactivo', component: FormularioReactivoComponent}
];
