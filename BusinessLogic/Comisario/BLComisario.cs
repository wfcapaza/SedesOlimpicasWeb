using DataAccess;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BLComisario : IBLComisario
    {
        private readonly IDAComisario _comisario;
        public BLComisario(IDAComisario comisario)
        {
            _comisario = comisario;
        }
        public async Task<List<Comisario>> ListaComisarios()
        {
            return await _comisario.ListaComisarios();
        }
        public async Task<Comisario> ObtenerComisario(int idComisario)
        {
            return await _comisario.ObtenerComisario(idComisario); ;
        }
        public async Task<bool> CrearComisario(Comisario comisario)
        {
            return await _comisario.CrearComisario(comisario);
        }
        public async Task<bool> EditarComisario(Comisario comisario)
        {
            return await _comisario.EditarComisario(comisario);
        }
        public async Task<bool> EliminarComisario(int idComisario)
        {
            return await _comisario.EliminarComisario(idComisario);
        }        
    }
}
