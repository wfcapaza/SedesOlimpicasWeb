using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IBLEvento
    {
        Task<List<Evento>> ListaEventos();
        Task<Evento> ObtenerEvento(int idEvento);
        Task<bool> CrearEvento(Evento evento);
        Task<bool> EditarEvento(Evento evento);
        Task<bool> EliminarEvento(int idEvento);
    }
}
