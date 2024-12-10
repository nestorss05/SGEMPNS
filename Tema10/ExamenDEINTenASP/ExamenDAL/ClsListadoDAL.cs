using ExamenENT;
using System.Collections.ObjectModel;

namespace ExamenDAL
{
    public class ClsListadoDAL
    {
        /// <summary>
        /// Metodo que devuelve un listado de candidatos completo
        /// Pre: ninguna
        /// Post: siempre devuelve un ObservableCollection de candidatos
        /// </summary>
        /// <returns>Listado de candidatos completo</returns>
        public static ObservableCollection<ClsCandidato> ListadoCandidatosDAL()
        {
            return new ObservableCollection<ClsCandidato>()
            {
                new ClsCandidato(1, "Paulie Gualtieri"),
                new ClsCandidato(2, "Christopher Moltisanti"),
                new ClsCandidato(3, "Silvio Dante"),
                new ClsCandidato(4, "Vito Spatafore"),
                new ClsCandidato(5, "Ralph Cifaretto"),
                new ClsCandidato(6, "Furio Giunta"),
                new ClsCandidato(7, "Carlo Gervassi"),
                new ClsCandidato(8, "Jackie Aprile, Jr"),
                new ClsCandidato(9, "Richie Aprile"),
                new ClsCandidato(10, "Bobby Baccalieri"),
                new ClsCandidato(11, "Phil Leotardo"),
                new ClsCandidato(12, "Big Pussy Bonpensiero"),
                new ClsCandidato(13, "Benny Fazio"),
                new ClsCandidato(14, "Tony Blundetto"),
                new ClsCandidato(15, "Little Paulie Germani")
            };
        }

        /// <summary>
        /// Metodo que devuelve un candidato escogido del listado de candidatos mediante su ID
        /// Pre: el ID de un candidato debe ser valido (1 - 15)
        /// Post: puede devolver null si el ID no se encuentra en el listado de candidatos. De lo contrario, devolvera al candidato encontrado
        /// </summary>
        /// <param name="id">ID del candidato a buscar</param>
        /// <returns>Candidato escogido mediante ID</returns>
        public static ClsCandidato EscogerCandidatoDAL(int id)
        {
            ObservableCollection<ClsCandidato> candidatos = ListadoCandidatosDAL();
            ClsCandidato candidatoBuscado = (ClsCandidato)candidatos.Where(cn => cn.Id == id).First();
            return candidatoBuscado;
        }

    }
}
