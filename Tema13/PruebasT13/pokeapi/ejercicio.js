/**
 * Metodo que llama a la API para obtener el listado de pokemons
 * Pre: ninguna
 * Post: ninguna
 */
function pedirDatos() {

    var ajax = new XMLHttpRequest();
    ajax.open("GET", "https://pokeapi.co/api/v2/pokemon?limit=135&offset=251");

    //Definicion estados
    ajax.onreadystatechange = function () {
    if (ajax.readyState < 4) {
        //aquí se puede poner una imagen de un reloj o un texto “Cargando”
    } else 
        if (ajax.readyState == 4 && ajax.status == 200) {
            var arrayPokemons = JSON.parse(ajax.responseText);
            listarPokemon(arrayPokemons)
        }
    };
    ajax.send();
}

/**
 * Metodo que pasa al HTML el listado de pokemons en una tabla
 * Pre: el listado de pokemons debe estar en un formato JSON valido
 * Post: ninguna
 * @param {*} arrayPokemons 
 */
function listarPokemon(arrayPokemons) {
    var datos = document.getElementById("datos");
    datos.innerHTML = "";
    var pokes = document.getElementById("pokemon");
    var html = "<ul>";
    for (let i = 0; i < arrayPokemons.results.length; i++) {
        html += `<li>
                <div class="pokemon-item" onclick="detalles('${arrayPokemons.results[i].url}')">
                    ${arrayPokemons.results[i].name}
                </div>
            </li>`;
    }
    html += "</ul>";
    pokes.innerHTML = html;
}

/**
 * Metodo que se conecta a la API para obtener el pokemon especificado por ID
 * Pre: el URL del pokemon en cuestion debe ser valido y debe funcionar
 * Post: ninguna
 * @param {*} url 
 */
function detalles(url) {

    var ajax = new XMLHttpRequest();
    ajax.open("GET", url);

    //Definicion estados
    ajax.onreadystatechange = function () {
        if (ajax.readyState < 4) {
            //aquí se puede poner una imagen de un reloj o un texto “Cargando”
        } else {
            if (ajax.readyState == 4 && ajax.status == 200) {
                var pokemon = JSON.parse(ajax.responseText);
                mostrarDetalles(pokemon)
            }
        };
    }
    
    ajax.send();
    
}

/**
 * Metodo que pasa los detalles de un pokemon al HTML
 * Pre: el pokemon debe estar en un formato JSON valido
 * Post: ninguna
 * @param {*} pokemon 
 */
function mostrarDetalles(pokemon) {

    var detalles = document.getElementById("detalles");
    detalles.innerHTML = "";

    detalles.innerHTML = `
        <h3>Detalles del Pokemon</h3>
        <img src="${pokemon.sprites.front_default}" alt="Sin imagen" style="width: 150px; height: 150px;">
        <p><strong>Nombre:</strong> ${pokemon.name}</p>
        <p><strong>ID:</strong> ${pokemon.id}</p>
        <p><strong>Peso:</strong> ${pokemon.weight}</p>
        <p><strong>Altura:</strong> ${pokemon.height}</p>
        <p><strong>Habilidades:</strong> 
            ${pokemon.abilities.map(a => a.ability.name).join(', ')}
        </p>
    `;

}