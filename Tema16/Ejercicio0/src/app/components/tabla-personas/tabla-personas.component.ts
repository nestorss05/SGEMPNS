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
import { ReactiveFormsModule } from '@angular/forms';
import { PersonaDialogComponent } from '../persona-dialog/persona-dialog.component';
import { MatDialog } from '@angular/material/dialog';

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

  constructor(private personaService: PersonasService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.getPersonas();
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

  openDialog(): void {
    const dialogRef = this.dialog.open(PersonaDialogComponent, {
      width: '400px'
    });
  
    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.crearPersona(result);
      }
    });
  }

  async crearPersona(personaData: Persona) {
    this.personaService.postPersonas(personaData).subscribe({
      next: (response) => {
        alert("La persona ha sido añadida exitosamente");
        this.getPersonas();
      },
      error: (error)=>{
        alert("Ha ocurrido un error al añadir la persona");
      }
    })
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
