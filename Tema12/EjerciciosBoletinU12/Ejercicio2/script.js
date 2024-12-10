window.onload = inicializaEventos;

function inicializaEventos() {

document.getElementById("btnSaludar").addEventListener("click", saludar,false);

}

function saludar() {
    var nombre = document.getElementById("nombre").value;
    var apellidos = document.getElementById("apellidos").value;
    var persona = new Persona(nombre, apellidos)
    alert("Hola " + persona.nombre + " " + persona.apellidos);
}