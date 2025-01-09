/**
 * Metodo que llama a la API para obtener el listado de pokemons
 * Pre: ninguna
 * Post: ninguna
 */
function pedirDatos() {

    var ajax = new XMLHttpRequest();
    ajax.open("GET", "https://nestorsanchezasp.azurewebsites.net/API/Personas");

    //Definicion estados
    ajax.onreadystatechange = function () {
    if (ajax.readyState < 4) {
        //aquí se puede poner una imagen de un reloj o un texto “Cargando”
    } else 
        if (ajax.readyState == 4 && ajax.status == 200) {
            var arrayPersonas = JSON.parse(ajax.responseText);
            listarPersonas(arrayPersonas)
        }
    };
    ajax.send();
}

/**
 * Metodo que pasa al HTML el listado de personas en una tabla
 * Pre: el listado de personas debe estar en un formato JSON valido
 * Post: ninguna
 * @param {*} arrayPersonas 
 */
function listarPersonas(arrayPersonas) {
    var datos = document.getElementById("datos");
    datos.innerHTML = "";

    var info = document.getElementById("info");
    var html = "<h1>Listado de personas</h1>";
    html += "Para eliminar una persona, haga clic en ella. Para agregar una persona, navega hacia abajo del todo en la pagina.";
    info.innerHTML = html;

    var personas = document.getElementById("pokemon");
    html = "<ul>";
    for (let i = 0; i < arrayPersonas.length; i++) {
        html += `<li>
                <div class="pokemon-item" onclick="borrado('${arrayPersonas[i].id}')">
                    ${arrayPersonas[i].nombre}
                </div>
            </li>`;
    }
    html += "</ul>";
    personas.innerHTML = html;

    var creator = document.getElementById("creator");
    html = "<h1>Agregar persona</h1>";
    html += "<form id=registro-form>";
    html += "<label for='nombre'>Nombre: </label>";
    html += "<input type='text' id='nombre' name='nombre' required> <br>";
    html += "<label for='apellidos'>Apellidos: </label>";
    html += "<input type='text' id='apellidos' name='apellidos' required> <br>";
    html += "<label for='telefono'>Telefono: </label>";
    html += "<input type='text' id='telefono' name='telefono' required> <br>";
    html += "<label for='direccion'>Direccion: </label>";
    html += "<input type='text' id='direccion' name='direccion' required> <br>";
    html += "<label for='foto'>Foto (URL): </label>";
    html += "<input type='url' id='foto' name='foto' required> <br>";
    html += "<label for='fechaNacimiento'>Fecha de nacimiento: </label>";
    html += "<input type='date' id='fechaNacimiento' name='fechaNacimiento' required> <br>";
    html += "<label for='idDepartamento'>ID del departamento: </label>";
    html += "<input type='number' id='idDepartamento' name='idDepartamento' required> <br>";
    html += "<button type='submit'>Enviar</button>";
    html += "</form>";
    creator.innerHTML = html;

    document.getElementById('registro-form').addEventListener('submit', function (event) {
    
        event.preventDefault();

        const persona = {
            nombre: document.getElementById('nombre').value,
            apellidos: document.getElementById('apellidos').value,
            telefono: document.getElementById('telefono').value,
            direccion: document.getElementById('direccion').value,
            foto: document.getElementById('foto').value,
            fechaNacimiento: document.getElementById('fechaNacimiento').value,
            idDepartamento: parseInt(document.getElementById('idDepartamento').value, 10)
        };
    
        const ajax = new XMLHttpRequest();
    
        ajax.open("POST", "https://nestorsanchezasp.azurewebsites.net/API/Personas/", true);
        ajax.setRequestHeader("Content-Type", "application/json;charset=UTF-8");
    
        ajax.onreadystatechange = function () {
            if (ajax.readyState === 4) {
                if (ajax.status === 200 || ajax.status === 201) {
                    alert("Persona agregada con exito. Se procedera a recargar la pagina en unos segundos.");
                } else {
                    alert("Error al agregar la persona. C: " + ajax.status);
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

/**
 * Metodo que elimina una persona
 * Pre: ID de la persona a eliminar
 * Post: ninguna
 * @param {*} idPersona 
 */
function borrado(idPersona) {
    var borrar = confirm("¿Estas seguro de que desea borrar a la persona?")
    if (borrar) {
        alert("Suponte que se empieza a borrar el coso ese")
        var ajax = new XMLHttpRequest();
        var enlace = "https://nestorsanchezasp.azurewebsites.net/API/Personas/" + idPersona
        ajax.open("DELETE", enlace);

        ajax.onreadystatechange = function () {
            if (ajax.readyState < 4) {
                // Aquí se puede mostrar un indicador visual de carga
            } else if (ajax.readyState === 4) {
                if (ajax.status === 200) {
                    alert("Persona eliminada con exito. Se procedera a recargar la pagina en unos segundos.");
                } else {
                    alert("Error al eliminar la persona. C: " + ajax.status);
                }
            }
        };
    
        ajax.send();
        setTimeout(() => {
            location.reload(true);
        }, 4000);

    }
}