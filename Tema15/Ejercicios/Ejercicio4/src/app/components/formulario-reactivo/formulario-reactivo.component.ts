import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field'; 
import { MatCardModule } from '@angular/material/card'; 
import { MatButtonModule } from '@angular/material/button';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-formulario-reactivo',
  imports: [ReactiveFormsModule, NgIf, MatFormFieldModule, MatCardModule, MatButtonModule, MatInputModule],
  templateUrl: './formulario-reactivo.component.html',
  styleUrl: './formulario-reactivo.component.css'
})
export class FormularioReactivoComponent implements OnInit {
  formulario: FormGroup;
  constructor() {}
  ngOnInit(): void {
    this.formulario=new FormGroup({
        nombre: new FormControl('',[Validators.required, Validators.minLength(4)]),
        apellidos: new FormControl('',[Validators.required])
    });
  }

  saluda() {
    if (this.formulario.valid) {
      alert(`Hola ${this.formulario.controls.nombre.value} ${this.formulario.controls.apellidos.value}`);
    }
  }
}