import { Component, OnInit, signal, ViewChild, WritableSignal, ChangeDetectionStrategy } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Persona } from '../../../interfaces/persona';
import { PersonasService } from '../../../services/personas.service';
import { MatButtonModule } from '@angular/material/button'
import { MatTableModule, MatTableDataSource } from '@angular/material/table'
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator'
import { MatSelectModule } from '@angular/material/select';
import { MatInputModule } from '@angular/material/input';
import { MatFormFieldModule } from '@angular/material/form-field';
import { FormControl, FormGroup, Validators, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-tabla-personas',
  imports: [CommonModule, MatButtonModule,  MatTableModule, MatPaginatorModule, MatFormFieldModule, MatInputModule, MatSelectModule, ReactiveFormsModule],
  templateUrl: './tabla-personas.component.html',
  styleUrl: './tabla-personas.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class TablaPersonasComponent implements OnInit {

  @ViewChild(MatPaginator) paginator: MatPaginator;
  listadoPersonas: WritableSignal<Persona[]> = signal<Persona[]>([]);

  columnas: string[] = ["id", "nombre", "apellidos", "fechaNac", "actions"];
  dataSource = new MatTableDataSource<Persona>([]);
  personaForm: FormGroup;

  constructor(private personaService: PersonasService) { }

  ngOnInit(): void {
    this.getPersonas();
    this.personaForm=new FormGroup({
      nombre: new FormControl('',[Validators.required]),
      apellidos: new FormControl('',[Validators.required]),
      telefono: new FormControl('',[Validators.required]),
      direccion: new FormControl('',[Validators.required]),
      foto: new FormControl('',[Validators.required]),
      fechaNacimiento: new FormControl('',[Validators.required]),
      idDepartamento: new FormControl('',[Validators.required]),
    });
  }

  ngAfterViewInit(): void {
    this.dataSource.paginator = this.paginator;
  }

  async getPersonas() {
    this.personaService.getPersonas().subscribe({
      next: (response) => {
        this.listadoPersonas.set(response);
        
        this.dataSource.data = this.listadoPersonas();
        if (this.paginator) {
          this.dataSource.paginator = this.paginator;
        }

      },
      error: (error)=>{
        alert("Ha ocurrido un error al obtener los datos del servidor");
      }
    });
  }

  async crearPersona() {
    if (this.personaForm.valid) {
      var per: Persona = this.personaForm.value;
      console.log(per)
      this.personaService.postPersonas(per).subscribe({
        next: (response) => {
          alert("La persona ha sido añadida exitosamente");
          this.getPersonas();
          this.personaForm.reset();
        },
        error: (error)=>{
          alert("Ha ocurrido un error al añadir la persona");
        }
      })
    }
  }

  async deletePersona(id?: Number) {
    var borrar = confirm("¿Estas seguro de que desea borrar a la persona?")

    if (borrar) {
      this.personaService.deletePersonas(id).subscribe({
        next: (response) => {
          alert("La persona ha sido borrada exitosamente")
        
          this.getPersonas()
        },
        error: (error)=>{
          alert("Ha ocurrido un error al borrar la persona");
        }
      })
    }
  }

}
