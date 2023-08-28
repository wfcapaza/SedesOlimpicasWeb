using DataAccess;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BLEvento : IBLEvento
    {
        private readonly IDAEvento _evento;

        public BLEvento(IDAEvento evento)
        {
            _evento = evento;
        }
        public async Task<List<Evento>> ListaEventos()
        {
            return await _evento.ListaEventos();
        }
        public async Task<Evento> ObtenerEvento(int idEvento)
        {
            return await _evento.ObtenerEvento(idEvento);
        }
        public async Task<bool> CrearEvento(Evento evento)
        {
            return await _evento.CrearEvento(evento);
        }
        public async Task<bool> EditarEvento(Evento evento)
        {
            return await _evento.EditarEvento(evento);
        }
        public async Task<bool> EliminarEvento(int idEvento)
        {
            return await _evento.EliminarEvento(idEvento);
        }        
    }
}
