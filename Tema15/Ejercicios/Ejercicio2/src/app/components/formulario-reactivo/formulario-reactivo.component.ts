import { NgIf } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { ReactiveFormsModule, FormGroup, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-formulario-reactivo',
  imports: [ReactiveFormsModule, NgIf],
  templateUrl: './formulario-reactivo.component.html',
  styleUrl: './formulario-reactivo.component.css'
})
export class FormularioReactivoComponent implements OnInit {
  formulario: FormGroup;
  constructor() {}
  ngOnInit(): void {
    this.formulario=new FormGroup({
        nombre: new FormControl('',[Validators.required]),
        apellidos: new FormControl('',[])
    });
  }

  saluda() {
    if (this.formulario.controls.nombre.value != "") {
      alert('Hola ' + this.formulario.controls.nombre.value + ' ' + this.formulario.controls.apellidos.value);
    }
  }
}
