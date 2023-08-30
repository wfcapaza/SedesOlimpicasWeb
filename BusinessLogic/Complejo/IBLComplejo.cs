using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IBLComplejo
    {
        Task<List<Complejo>> ListaComplejos();
        Task<Complejo> ObtenerComplejo(int idComplejo);
        Task<bool> CrearComplejo(Complejo complejo);
        Task<bool> EditarComplejo(Complejo complejo);
        Task<bool> EliminarComplejo(int idComplejo);
        Task<bool> ValidarNroMaxSedes(int idSede);
    }
}
