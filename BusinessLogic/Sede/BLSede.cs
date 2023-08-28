using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BLSede:IBLSede
    {
        private readonly IDASede _sede;
        public BLSede(IDASede sede)
        {
            _sede = sede;
        }
        public async Task<List<Sede>> ListaSedes()
        {
            return await _sede.ListaSedes();
        }
        public async Task<Sede> ObtenerSede(int idSede)
        {
            return await _sede.ObtenerSede(idSede); ;
        }
        public async Task<bool> CrearSede(Sede sede)
        {
            return await _sede.CrearSede(sede);
        }
        public async Task<bool> EditarSede(Sede sede)
        {
            return await _sede.EditarSede(sede);
        }
        public async Task<bool> EliminarSede(int idSede)
        {
            return await _sede.EliminarSede(idSede);
        }
    }
}
