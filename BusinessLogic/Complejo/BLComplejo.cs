using DataAccess;
using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BLComplejo : IBLComplejo
    {
        private readonly IDAComplejo _complejo;
        private readonly IDASede _sede;
        public BLComplejo(IDAComplejo complejo, IDASede sede)
        {
            _complejo = complejo;
            _sede = sede;
        }
        public async Task<List<Complejo>> ListaComplejos()
        {
            return await _complejo.ListaComplejos();
        }
        public async Task<Complejo> ObtenerComplejo(int idComplejo)
        {
            return await _complejo.ObtenerComplejo(idComplejo);
        }
        public async Task<bool> CrearComplejo(Complejo complejo)
        {
            return await _complejo.CrearComplejo(complejo);
        }
        public async Task<bool> EditarComplejo(Complejo complejo)
        {
            return await _complejo.EditarComplejo(complejo);
        }
        public async Task<bool> EliminarComplejo(int idComplejo)
        {
            return await _complejo.EliminarComplejo(idComplejo);
        } 
        public async Task<bool> ValidarNroMaxSedes(int idSede)
        {
            var sede = await _sede.ObtenerSede(idSede);
            var complejosPorSede = await _complejo.ListaComplejosPorSede(idSede);

            if(sede.NroComplejos > complejosPorSede.Count)
                return true;

            return false;
        }
    }
}
