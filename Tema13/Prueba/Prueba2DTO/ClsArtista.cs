using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba2DTO
{
    public class ClsArtista2
    {
        public int IdArtista { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }
        public string NombreArtistico { get; set; }
        public string DNI { get; set; }
        public DateTime FechaNac { get; set; }
        public string Residencia { get; set; }

        public ClsArtista2() { }

        public ClsArtista2(int idArtista, string nombre, string apellidos, string nombreArtistico, string dNI, DateTime fechaNac, string residencia)
        {
            IdArtista = idArtista;
            Nombre = nombre;
            Apellidos = apellidos;
            NombreArtistico = nombreArtistico;
            DNI = dNI;
            FechaNac = fechaNac;
            Residencia = residencia;
        }
    }
}
