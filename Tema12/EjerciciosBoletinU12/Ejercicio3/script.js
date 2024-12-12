// Constante que almacena los modelos por marca
const modelosPorMarca = {
    toyota: ['Corolla', 'Camry', 'RAV4'],
    ford: ['Focus', 'Fiesta', 'Mondeo'],
    bmw: ['X5', '320i', 'M3']
};
  
// Constantes que guardan los IDs del Dropdown y del listado de modelos
const marcaSelect = document.getElementById('marca');
const modeloSelect = document.getElementById('modelos-lista');
  
// Al cambiar la marca, se ejecutara esta funcion
marcaSelect.addEventListener('change', () => {

    // La marca seleccionada sera el valor de la marca escogida en el dropdown
    const marcaSeleccionada = marcaSelect.value;

    // Si la marca seleccionada y los modelos por marca no son null, se recorreran los modelos de esa marca y se añadiran a la lista
    if (marcaSeleccionada && modelosPorMarca[marcaSeleccionada]) {
        const modelos = modelosPorMarca[marcaSeleccionada];
        modelos.forEach(modelo => {
            const li = document.createElement('li');
            li.textContent = modelo;
            modeloSelect.appendChild(li);
        });
    }
});