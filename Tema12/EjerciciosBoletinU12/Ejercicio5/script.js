// Contenedor del reloj
const relojContainer = document.getElementById('reloj');

// Metodo para obtener la hora formateada como HH:MM:SS
function obtenerHoraActual() {
    const fechaActual = new Date();
    const horas = String(fechaActual.getHours()).padStart(2, '0');
    const minutos = String(fechaActual.getMinutes()).padStart(2, '0');
    const segundos = String(fechaActual.getSeconds()).padStart(2, '0');
    return `${horas}:${minutos}:${segundos}`;
}

// Metodo para actualizar el reloj con imágenes
function actualizarReloj() {

    // Obten la hora actual
    const horaActual = obtenerHoraActual();

    // Limpia el contenido del reloj
    relojContainer.innerHTML = '';

    // Recorre cada caracter de la hora actual para establecer las imagenes segun numero o separador
    for (var char of horaActual) {

        // Crea un elemento imagen
        const img = document.createElement('img');

        // La ruta del digito se escogera dependiendo del numero o de si son dos puntos
        if (char == ':') {
            img.src = `./imgs/dosPuntos.gif`;
            
        } else {
            img.src = `./imgs/${char}.gif`;
        }

        // Si la imagen no carga, muestra el caracter como alternativa
        img.alt = char;

        // Mete la imagen en el contenedor del reloj
        relojContainer.appendChild(img);

    }
}

// Actualiza el reloj cada segundo
setInterval(actualizarReloj, 1000);

// Llama a la funcion que actualiza el reloj al cargar la pagina
actualizarReloj();