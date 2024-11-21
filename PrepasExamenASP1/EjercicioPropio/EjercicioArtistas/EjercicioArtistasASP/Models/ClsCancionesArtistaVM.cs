using EjercicioArtistasBL;
using EjercicioArtistasDAL;
using EjercicioArtistasENT;

namespace EjercicioArtistasASP.Models
{
    public class ClsCancionesArtistaVM
    {
        #region Atributos
        private List<ClsArtista>? artistas;
        private List<ClsCancion> canciones;
        private int cantidadCanciones;
        #endregion

        #region Propiedades
        public List<ClsArtista>? Artistas 
        { 
            get { return artistas; } 
        }
        public List<ClsCancion> Canciones {
            get { return canciones; } 
        }
        public int CantidadCanciones {
            get { return cantidadCanciones; } 
        }
        #endregion

        #region Constructores
        public ClsCancionesArtistaVM()
        { 
            artistas = ClsListadosBL.ListadoArtistasBL(); 
        }
        public ClsCancionesArtistaVM(int idArtista)
        {
            artistas = ClsListadosBL.ListadoArtistasBL();
            canciones = ClsListadosBL.ListadoCancionesBL(idArtista);
            cantidadCanciones = ClsListadosBL.CantidadCancionesArtistaBL(idArtista);
        }
        #endregion
    }
}
