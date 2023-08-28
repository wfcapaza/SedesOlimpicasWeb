using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDASede
    {
        Task<List<Sede>> ListaSedes();
        Task<Sede> ObtenerSede(int idSede);
        Task<bool> CrearSede(Sede sede);
        Task<bool> EditarSede(Sede sede);
        Task<bool> EliminarSede(int idSede);
    }
}
