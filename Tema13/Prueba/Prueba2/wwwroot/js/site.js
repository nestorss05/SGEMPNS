/**
 * Metodo que carga los datos de una cancion y de un artista de forma automatica
 */
document.addEventListener('DOMContentLoaded', function () {
    pedirDatosArtista()
    pedirDatosCancion()
});

/**
 * Metodo que llama a la API para obtener el listado de artistas
 * Pre: ninguna
 * Post: ninguna
 */
function pedirDatosArtista() {

    var recargaArtistas = document.getElementById("recargaArtistas");
    var html = "<img src='./preloader.gif' alt='Cargando' width='300'>";
    var ajax = new XMLHttpRequest();
    ajax.open("GET", "http://localhost:5189/API/Artista");

    //Definicion estados
    ajax.onreadystatechange = function () {
        if (ajax.readyState < 4) {
            recargaArtistas.innerHTML = html;
        } else
            if (ajax.readyState == 4 && ajax.status == 200) {
                var arrayArtistas = JSON.parse(ajax.responseText);
                listarArtistas(arrayArtistas)
                html = "";
                recargaArtistas.innerHTML = html;
            }
    };
    ajax.send();
}

/**
 * Metodo que llama a la API para obtener el listado de canciones
 * Pre: ninguna
 * Post: ninguna
 */
function pedirDatosCancion() {

    var recargaCanciones = document.getElementById("recargaCanciones");
    var html = "<img src='./preloader.gif' alt='Cargando' width='300'>";
    var ajax = new XMLHttpRequest();
    ajax.open("GET", "http://localhost:5189/API/Cancion");

    //Definicion estados
    ajax.onreadystatechange = function () {
        if (ajax.readyState < 4) {
            recargaCanciones.innerHTML = html;
        } else
            if (ajax.readyState == 4 && ajax.status == 200) {
                var arrayCanciones = JSON.parse(ajax.responseText);
                listarCanciones(arrayCanciones)
                html = "";
                recargaCanciones.innerHTML = html;
            }
    };
    ajax.send();
}

/**
* Metodo que pasa al HTML el listado de artistas en una tabla
* Pre: el listado de artistas debe estar en un formato JSON valido
* Post: ninguna
* @param {*} arrayArtistas 
*/
function listarArtistas(arrayArtistas) {

    var infoArtistas = document.getElementById("infoArtistas");
    var html = "<h2>Listado de artistas</h2>";
    html += "Para eliminar un artista, haga clic en el. Para agregar un artista, navega hacia abajo del todo en la pagina.";
    infoArtistas.innerHTML = html;

    var artistas = document.getElementById("artistas");
    html = "<ul>";
    for (let i = 0; i < arrayArtistas.length; i++) {
        html += `<li>
                <div onclick="borrarArtista('${arrayArtistas[i].idArtista}')">
                    ${arrayArtistas[i].idArtista}. ${arrayArtistas[i].nombre} ${arrayArtistas[i].apellidos} (${arrayArtistas[i].nombreArtistico}, ${arrayArtistas[i].residencia})
                </div>
            </li>`;
    }
    html += "</ul>";
    artistas.innerHTML = html;

    var creator = document.getElementById("creatorArtistas");
    html = "<h2>Agregar / modificar artista</h2>";
    html += "<form id=registro-form-artista>";
    html += "<label for='nombre'>Nombre: </label>";
    html += "<input type='text' id='nombre' name='nombre' required> <br>";
    html += "<label for='apellidos'>Apellidos: </label>";
    html += "<input type='text' id='apellidos' name='apellidos' required> <br>";
    html += "<label for='nombreArtistico'>Nombre Artistico: </label>";
    html += "<input type='text' id='nombreArtistico' name='nombreArtistico' required> <br>";
    html += "<label for='dni'>DNI: </label>";
    html += "<input type='text' id='dni' name='dni' required> <br>";
    html += "<label for='fechaNac'>Fecha de nacimiento: </label>";
    html += "<input type='date' id='fechaNac' name='fechaNac' required> <br>";
    html += "<label for='residencia'>Residencia: </label>";
    html += "<input type='text' id='residencia' name='residencia' required> <br>";
    html += "<button type='submit'>Accionar</button>";
    html += "</form>";
    creator.innerHTML = html;

    document.getElementById('registro-form-artista').addEventListener('submit', function (event) {

        event.preventDefault();
        var modificar = confirm("¿Modificar o crear? Si desea modificar, haga clic en aceptar. De lo contrario, haga clic en cancelar.")
        if (modificar) {
            var idModificar = prompt("Inserte el ID del artista a modificar");
            idModificar = parseInt(idModificar);
            const artista = {
                idArtista: idModificar,
                nombre: document.getElementById('nombre').value,
                apellidos: document.getElementById('apellidos').value,
                nombreArtistico: document.getElementById('nombreArtistico').value,
                dni: document.getElementById('dni').value,
                fechaNac: document.getElementById('fechaNac').value,
                residencia: document.getElementById('residencia').value,
            };
            modificarArtista(artista);
        } else {
            const artista = {
                idArtista: arrayArtistas[arrayArtistas.length - 1].idArtista + 1,
                nombre: document.getElementById('nombre').value,
                apellidos: document.getElementById('apellidos').value,
                nombreArtistico: document.getElementById('nombreArtistico').value,
                dni: document.getElementById('dni').value,
                fechaNac: document.getElementById('fechaNac').value,
                residencia: document.getElementById('residencia').value,
            };

            crearArtista(artista);
        }

    });

}

/**
* Metodo que pasa al HTML el listado de canciones en una tabla
* Pre: el listado de canciones debe estar en un formato JSON valido
* Post: ninguna
* @param {*} arrayCanciones 
*/
function listarCanciones(arrayCanciones) {

    var infoCanciones = document.getElementById("infoCanciones");
    var html = "<h2>Listado de canciones</h2>";
    html += "Para eliminar una cancion, haga clic en el. Para agregar una cancion, navega hacia abajo del todo en la pagina. NOTA: Modificar sobreescribira TODOS los datos que hayan en el objeto.";
    infoCanciones.innerHTML = html;

    var personas = document.getElementById("canciones");
    html = "<ul>";
    for (let i = 0; i < arrayCanciones.length; i++) {
        html += `<li>
                <div onclick="borrarCancion('${arrayCanciones[i].idCancion}')">
                    ${arrayCanciones[i].idCancion}. ${arrayCanciones[i].nombreArtista} - ${arrayCanciones[i].nombre} (${arrayCanciones[i].genero}, ${arrayCanciones[i].año})
                </div>
            </li>`;
    }
    html += "</ul>";
    personas.innerHTML = html;

    var arrayNombres = []
    arrayCanciones.forEach(function(art) {
        if (!arrayNombres.some(fila => fila[1] === art.nombreArtista)) {
            arrayNombres.push([art.idArtista, art.nombreArtista]);
        }
    });

    arrayNombres.sort((a, b) => a[0] - b[0])

    var creator = document.getElementById("creatorCanciones");
    var nombresArtistas = arrayNombres.map(fila => `<option value="${fila[0]}">${fila[1]}</option>`).join("");

    html = "<h2>Agregar / modificar cancion</h2>";
    html += "<form id=registro-form-cancion>";
    html += "<label for='idArtista'>Artista: </label>";
    html += `<select id='idArtista' name='idArtista' required>${nombresArtistas}</select> <br>`;
    html += "<label for='nombreCan'>Nombre: </label>";
    html += "<input type='text' id='nombreCan' name='nombreCan' required> <br>";
    html += "<label for='duracion'>Duracion: </label>";
    html += "<input type='time' id='duracion' name='duracion' required> <br>";
    html += "<label for='genero'>Genero: </label>";
    html += "<input type='text' id='genero' name='genero' required> <br>";
    html += "<label for='año'>Año: </label>";
    html += "<input type='number' id='año' name='año' required> <br>";
    html += "<button type='submit'>Accionar</button>";
    html += "</form>";
    creator.innerHTML = html;

    document.getElementById('registro-form-cancion').addEventListener('submit', function (event) {

        event.preventDefault();
        var modificar = confirm("¿Modificar o crear? Si desea modificar, haga clic en aceptar. De lo contrario, haga clic en cancelar. NOTA: Modificar sobreescribira TODOS los datos que hayan en el objeto.")
        if (modificar) {
            var idModificar = prompt("Inserte el ID de la cancion a modificar");
            idModificar = parseInt(idModificar);
            const cancion = {
                idCancion: idModificar,
                idArtista: document.getElementById('idArtista').value,
                nombre: document.getElementById('nombreCan').value,
                duracion: document.getElementById('duracion').value,
                genero: document.getElementById('genero').value,
                año: document.getElementById('año').value,
            };
            modificarCancion(cancion);
        } else {
            const cancion = {
                idCancion: arrayCanciones[arrayCanciones.length - 1].idCancion + 1,
                idArtista: document.getElementById('idArtista').value,
                nombre: document.getElementById('nombreCan').value,
                duracion: document.getElementById('duracion').value,
                genero: document.getElementById('genero').value,
                año: document.getElementById('año').value,
            };

            crearCancion(cancion);
        }

    });

}

/**
 * Metodo crearArtista: crea un artista y metelo en la API
 * Pre: el artista debe estar bien formado
 * Post: nada
 * @param {any} artista
 */
function crearArtista(artista) {

    var recargaArtistas = document.getElementById("recargaArtistas");
    const ajax = new XMLHttpRequest();

    ajax.open("POST", "http://localhost:5189/API/Artista", true);
    ajax.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

    ajax.onreadystatechange = function () {
        if (ajax.readyState < 4) {
            html = "<img src='./preloader.gif' alt='Cargando' width='300'>";
            recargaArtistas.innerHTML = html;
        } else if (ajax.readyState === 4) {
            if (ajax.status === 200 || ajax.status === 201) {
                alert("Artista agregado con exito. Se procedera a recargar la pagina en unos segundos.");
            } else {
                alert("Error al agregar al artista. C: " + ajax.status);
            }
            html = "";
            recargaArtistas.innerHTML = html;
        }
    };

    // Enviar los datos en formato JSON
    ajax.send(JSON.stringify(artista));
    setTimeout(() => {
        location.reload(true);
    }, 4000);
}

/**
 * Metodo crearCancion: crea una cancion y metelo en la API
 * Pre: la cancion debe estar bien formada
 * Post: nada
 * @param {any} cancion
 */
function crearCancion(cancion) {
    var recargaCanciones = document.getElementById("recargaCanciones");
    const ajax = new XMLHttpRequest();

    ajax.open("POST", "http://localhost:5189/API/Cancion", true);
    ajax.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

    ajax.onreadystatechange = function () {
        if (ajax.readyState < 4) {
            html = "<img src='./preloader.gif' alt='Cargando' width='300'>";
            recargaCanciones.innerHTML = html;
        } else if (ajax.readyState === 4) {
            if (ajax.status === 200 || ajax.status === 201) {
                alert("Cancion agregada con exito. Se procedera a recargar la pagina en unos segundos.");
            } else {
                alert("Error al agregar la cancion. C: " + ajax.status);
            }
            html = "";
            recargaCanciones.innerHTML = html;
        }
    };

    // Enviar los datos en formato JSON
    ajax.send(JSON.stringify(cancion));
    setTimeout(() => {
        location.reload(true);
    }, 4000);
}

/**
 * Metodo que modifica un artista
 * Pre: ID del artista a modificar
 * Post: ninguna
 * @param {any} artista
 */
function modificarArtista(artista) {
    var recargaArtistas = document.getElementById("recargaArtistas");
    const ajax = new XMLHttpRequest();

    ajax.open("PUT", "http://localhost:5189/API/Artista/" + artista.idArtista, true);
    ajax.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

    ajax.onreadystatechange = function () {
        if (ajax.readyState < 4) {
            html = "<img src='./preloader.gif' alt='Cargando' width='300'>";
            recargaArtistas.innerHTML = html;
        } else if (ajax.readyState === 4) {
            if (ajax.status === 200 || ajax.status === 201) {
                alert("Artista editado con exito. Se procedera a recargar la pagina en unos segundos.");
            } else {
                alert("Error al editar el artista. C: " + ajax.status);
            }
            html = "";
            recargaArtistas.innerHTML = html;
        }
    };

    // Enviar los datos en formato JSON
    ajax.send(JSON.stringify(artista));
    setTimeout(() => {
        location.reload(true);
    }, 4000);
}

/**
 * Metodo que modifica una cancion
 * Pre: ID de la cancion a modificar
 * Post: ninguna
 * @param {any} cancion
 */
function modificarCancion(cancion) {
    var recargaCanciones = document.getElementById("recargaCanciones");
    const ajax = new XMLHttpRequest();

    ajax.open("PUT", "http://localhost:5189/API/Cancion/" + cancion.idCancion, true);
    ajax.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

    ajax.onreadystatechange = function () {
        if (ajax.readyState < 4) {
            html = "<img src='./preloader.gif' alt='Cargando' width='300'>";
            recargaCanciones.innerHTML = html;
        } else if (ajax.readyState === 4) {
            if (ajax.status === 200 || ajax.status === 201) {
                alert("Cancion editada con exito. Se procedera a recargar la pagina en unos segundos.");
            } else {
                alert("Error al editar la cancion. C: " + ajax.status);
            }
            html = "";
            recargaCanciones.innerHTML = html;
        }
    };

    // Enviar los datos en formato JSON
    ajax.send(JSON.stringify(cancion));
    setTimeout(() => {
        location.reload(true);
    }, 4000);
}

/**
 * Metodo que elimina un artista
 * Pre: ID del artista a eliminar
 * Post: ninguna
 * @param {*} idArtista 
 */
function borrarArtista(idArtista) {
    var recargaArtistas = document.getElementById("recargaArtistas");
    var borrar = confirm("¿Estas seguro de que desea borrar al artista?")
    if (borrar) {
        var ajax = new XMLHttpRequest();
        var enlace = "http://localhost:5189/API/Artista/" + idArtista
        ajax.open("DELETE", enlace);

        ajax.onreadystatechange = function () {
            if (ajax.readyState < 4) {
                html = "<img src='./preloader.gif' alt='Cargando' width='300'>";
                recargaArtistas.innerHTML = html;
            } else if (ajax.readyState === 4) {
                if (ajax.status === 200) {
                    alert("Artista eliminado con exito. Se procedera a recargar la pagina en unos segundos.");
                } else {
                    alert("Error al eliminar el artista. C: " + ajax.status);
                }
                html = "";
                recargaArtistas.innerHTML = html;
            }
        };

        ajax.send();
        setTimeout(() => {
            location.reload(true);
        }, 4000);

    }
}

/**
 * Metodo que elimina una cancion
 * Pre: ID de la cancion a eliminar
 * Post: ninguna
 * @param {*} idCancion 
 */
function borrarCancion(idCancion) {
    var recargaCanciones = document.getElementById("recargaCanciones");
    var borrar = confirm("¿Estas seguro de que desea borrar a la cancion?")
    if (borrar) {
        var ajax = new XMLHttpRequest();
        var enlace = "http://localhost:5189/API/Cancion/" + idCancion
        ajax.open("DELETE", enlace);

        ajax.onreadystatechange = function () {
            if (ajax.readyState < 4) {
                html = "<img src='./preloader.gif' alt='Cargando' width='300'>";
                recargaCanciones.innerHTML = html;
            } else if (ajax.readyState === 4) {
                if (ajax.status === 200) {
                    alert("Cancion eliminada con exito. Se procedera a recargar la pagina en unos segundos.");
                } else {
                    alert("Error al eliminar la cancion. C: " + ajax.status);
                }
                html = "";
                recargaCanciones.innerHTML = html;
            }
        };

        ajax.send();
        setTimeout(() => {
            location.reload(true);
        }, 4000);

    }
}