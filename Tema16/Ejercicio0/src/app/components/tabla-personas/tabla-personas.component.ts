import { Component, OnInit } from '@angular/core';
import { Persona } from '../../../interfaces/persona';
import { PersonasService } from '../../../services/personas.service';

@Component({
  selector: 'app-tabla-personas',
  imports: [],
  templateUrl: './tabla-personas.component.html',
  styleUrl: './tabla-personas.component.scss'
})
export class TablaPersonasComponent {
  listadoPersonas:Persona[];
  constructor(private personaService: PersonasService) { }

  ngOnInit(): void {
    this.getPersonas();
  }

  async getPersonas() {
    this.personaService.getPersonas().subscribe({
      next:(response) =>{
        this.listadoPersonas=response;
      },
      error: (error)=>{
        alert("Ha ocurrido un error al obtener los datos del servidor");
      }
    });
  }

}
