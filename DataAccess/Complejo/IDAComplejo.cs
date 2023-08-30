using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDAComplejo
    {
        Task<List<Complejo>> ListaComplejos();
        Task<List<Complejo>> ListaComplejosPorSede(int idSede);
        Task<Complejo> ObtenerComplejo(int idComplejo);
        Task<bool> CrearComplejo(Complejo complejo);
        Task<bool> EditarComplejo(Complejo complejo);
        Task<bool> EliminarComplejo(int idComplejo);
    }
}
