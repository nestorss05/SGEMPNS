import { Component, Inject  } from '@angular/core';
import { FormGroup, FormControl, Validators, ReactiveFormsModule } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA, MatDialogModule } from '@angular/material/dialog';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';

@Component({
  selector: 'app-persona-dialog',
  standalone: true,
  imports: [
    CommonModule,
    MatDialogModule,
    MatFormFieldModule,
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule
  ],
  templateUrl: './persona-dialog.component.html',
  styleUrl: './persona-dialog.component.scss'
})
export class PersonaDialogComponent {
  personaForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<PersonaDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {
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

  submit(): void {
    if (this.personaForm.valid) {
      this.dialogRef.close(this.personaForm.value);
    }
  }

  close(): void {
    this.dialogRef.close();
  }

}
