function pedirDatos() {
    var ajax = new XMLHttpRequest();
    ajax.open("GET", "https://pokeapi.co/api/v2/pokemon");

    //Definicion estados
    ajax.onreadystatechange = function () {
    if (ajax.readyState < 4) {
        //aquí se puede poner una imagen de un reloj o un texto “Cargando”
    } else 
        if (ajax.readyState == 4 && ajax.status == 200) {
            var arrayPokemons = JSON.parse(ajax.responseText);
            alert(ajax.responseText); // A quitar
            listarPokemon(arrayPokemons)
        }
    };
    ajax.send();
}

function listarPokemon(arrayPokemons) {
    var pokes = document.getElementById("pokemon");
    var html = "<table border=1>";
    html += "<tr> <td> ID </td>"
    html += "<td> Nombre </td>"
    html += "<td> </td> </tr>"
    for (i = 0; i < arrayPokemons.results.length; i++) {
        html += "<tr> <td>";
        html += i + 1;
        html += "</td> <td>";
        html += arrayPokemons.results[i].name;
        html += "</td> <td>";
        html += "Detalles (TODO)";
        html += "</td> </tr>";
    }
    html += "</table>";
    pokes.innerHTML = html;
}