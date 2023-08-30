using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IBLComisario
    {
        Task<List<Comisario>> ListaComisarios();
        Task<Comisario> ObtenerComisario(int idComisario);
        Task<bool> CrearComisario(Comisario comisario);
        Task<bool> EditarComisario(Comisario comisario);
        Task<bool> EliminarComisario(int idComisario);
        Task<List<Comisario>> ListaSedeConComisario();
    }
}
