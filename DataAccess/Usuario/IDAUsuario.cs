using Entities;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IDAUsuario
    {
        Task<Usuario> ObtenerUsuario(string correoElectronico, string contrasenha);
        Task<bool> CrearUsuario(Usuario usuario);
    }
}
