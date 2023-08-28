using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDAComisario
    {
        Task<List<Comisario>> ListaComisarios();
        Task<Comisario> ObtenerComisario(int idComisario);
        Task<bool> CrearComisario(Comisario comisario);
        Task<bool> EditarComisario(Comisario comisario);
        Task<bool> EliminarComisario(int idComisario);
    }
}
