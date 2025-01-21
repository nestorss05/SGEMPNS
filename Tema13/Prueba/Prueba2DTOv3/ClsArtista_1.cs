using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2DTOv3
{
    public class ClsArtista
    {
        public int IdCancion { get; set; }
        public int IdArtista { get; set; }
        public string Nombre { get; set; }
        public string Duracion { get; set; }
        public string Genero { get; set; }
        public int Año { get; set; }

        public ClsArtista() { }
        public ClsArtista(int idCancion, int idArtista, string nombre, string duracion, string genero, int año)
        {
            IdCancion = idCancion;
            IdArtista = idArtista;
            Nombre = nombre;
            Duracion = duracion;
            Genero = genero;
            Año = año;
        }
    }
}
