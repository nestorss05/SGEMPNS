// Tabla
const tabla = document.getElementById('tablaNS');

// Botones
const recorreCeldasBtn = document.getElementById('recorreCeldas');
const añadeFilaBtn = document.getElementById('añadeFila');
const borraFilaBtn = document.getElementById('borraFila');

// Cantidad de filas de la tabla
var cantidadFilas = tabla.rows.length + 1;

// Metodo para recorrer las celdas y mostrar su contenido
recorreCeldasBtn.addEventListener('click', () => {

    // Prepara el array a mostrar por alert
    var contenidoCeldas = [];

    // Recorre cada fila y celda para añadirla al array
    for (var fila of tabla.rows) {
        for (var celda of fila.cells) {
            contenidoCeldas.push(celda.textContent);
        }
    }

    // Muestra el contenido de las celdas separadas por coma
    alert(contenidoCeldas.join(', '));

});

// Metodo para añadir una nueva fila
añadeFilaBtn.addEventListener('click', () => {

    // Inserta una nueva fila
    const nuevaFila = tabla.insertRow();

    // Inserta dos celdas
    const celda1 = nuevaFila.insertCell(0);
    const celda2 = nuevaFila.insertCell(1);

    // Mete contenido en cada celda
    celda1.textContent = `Celda${cantidadFilas}1`;
    celda2.textContent = `Celda${cantidadFilas}2`;

    // Suma 1 al contador
    cantidadFilas++;

});

// Metodo para borrar la última fila
borraFilaBtn.addEventListener('click', () => {
    if (tabla.rows.length > 0) {
        tabla.deleteRow(tabla.rows.length - 1);
        cantidadFilas--; // Resta 1 al contador
    } else {
        alert('No hay filas para borrar.');
    }
});