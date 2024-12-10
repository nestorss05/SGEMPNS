using ExamenDAL;
using ExamenENT;
using System.Collections.ObjectModel;

namespace ExamenBL
{
    public class ClsListadoBL
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="numRondas"></param>
        /// <returns></returns>
        public static ObservableCollection<ClsCandidato> ListadoCandidatosAleatoriosRondasBL(int numRondas)
        {
            // TODO
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nCandidatos"></param>
        /// <param name="idCandidato"></param>
        /// <returns></returns>
        public static ObservableCollection<ClsCandidato> ObtenerCandidatosParaPregunta(int nCandidatos, int idCandidato)
        {
            // TODO
        }

        /// <summary>
        /// Metodo que devuelve un candidato escogido del listado de candidatos mediante su ID
        /// Pre: el ID de un candidato debe ser valido (1 - 15)
        /// Post: puede devolver null si el ID no se encuentra en el listado de candidatos. De lo contrario, devolvera al candidato encontrado
        /// </summary>
        /// <param name="id">ID del candidato a buscar</param>
        /// <returns>Candidato escogido mediante ID</returns>
        public static ClsCandidato EscogerCandidatoBL(int id)
        {
            ClsCandidato cand = ClsListadoDAL.EscogerCandidatoDAL(id);
            return cand;
        }
    }
}
