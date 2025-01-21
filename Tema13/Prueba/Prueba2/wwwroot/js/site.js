/**
 * Metodo que llama a la API para obtener el listado de artistas
 * Pre: ninguna
 * Post: ninguna
 */
function pedirDatosArtista() {

    var ajax = new XMLHttpRequest();
    ajax.open("GET", "http://localhost:5189/API/Artista");

    //Definicion estados
    ajax.onreadystatechange = function () {
        if (ajax.readyState < 4) {
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else
            if (ajax.readyState == 4 && ajax.status == 200) {
                var arrayArtistas = JSON.parse(ajax.responseText);
                listarArtistas(arrayArtistas)
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

    var ajax = new XMLHttpRequest();
    ajax.open("GET", "http://localhost:5189/API/Cancion");

    //Definicion estados
    ajax.onreadystatechange = function () {
        if (ajax.readyState < 4) {
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else
            if (ajax.readyState == 4 && ajax.status == 200) {
                var arrayCanciones = JSON.parse(ajax.responseText);
                listarArtistas(arrayCanciones)
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
    var datos = document.getElementById("datos");
    datos.innerHTML = "";

    var info = document.getElementById("info");
    var html = "<h1>Listado de artistas</h1>";
    html += "Para eliminar un artista, haga clic en el. Para agregar un artista, navega hacia abajo del todo en la pagina.";
    info.innerHTML = html;

    var personas = document.getElementById("artistas");
    html = "<ul>";
    for (let i = 0; i < arrayArtistas.length; i++) {
        html += `<li>
                <div onclick="borrado('${arrayArtistas[i].idArtista}')">
                    ${arrayArtistas[i].nombre}
                </div>
            </li>`;
    }
    html += "</ul>";
    personas.innerHTML = html;

    var creator = document.getElementById("creatorArtistas");
    html = "<h1>Agregar artista (WIP)</h1>";
    html += "<form id=registro-form>";
    html += "<label for='id'>ID: </label>";
    html += "<input type='text' id='id' name='id' required> <br>";
    html += "<label for='nombre'>Nombre: </label>";
    html += "<input type='text' id='nombre' name='nombre' required> <br>";
    html += "<label for='apellidos'>Apellidos: </label>";
    html += "<input type='text' id='apellidos' name='apellidos' required> <br>";
    html += "<label for='descripcion'>Descripcion: </label>";
    html += "<input type='text' id='descripcion' name='descripcion' required> <br>";
    html += "<button type='submit'>Enviar</button>";
    html += "</form>";
    creator.innerHTML = html;

    document.getElementById('registro-form').addEventListener('submit', function (event) {

        event.preventDefault();

        const persona = {
            id: document.getElementById('id').value,
            nombre: document.getElementById('nombre').value,
            apellidos: document.getElementById('apellidos').value,
            descripcion: document.getElementById('descripcion').value,
        };

        const ajax = new XMLHttpRequest();

        ajax.open("POST", "http://localhost:5189/API/Artista", true);
        ajax.setRequestHeader("Content-Type", "application/json;charset=UTF-8");

        ajax.onreadystatechange = function () {
            if (ajax.readyState === 4) {
                if (ajax.status === 200 || ajax.status === 201) {
                    alert("Artista agregado con exito. Se procedera a recargar la pagina en unos segundos.");
                } else {
                    alert("Error al agregar al artista. C: " + ajax.status);
                }
            }
        };

        // Enviar los datos en formato JSON
        ajax.send(JSON.stringify(persona));
        setTimeout(() => {
            location.reload(true);
        }, 4000);

    });

}

// WIP: listado de canciones
// WIP: eliminacion y modificacion
// WIP: icono de recarga