using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IBLSede
    {
        Task<List<Sede>> ListaSedes();
        Task<Sede> ObtenerSede(int idSede);
        Task<bool> CrearSede(Sede sede);
        Task<bool> EditarSede(Sede sede);
        Task<bool> EliminarSede(int idSede);
    }
}
