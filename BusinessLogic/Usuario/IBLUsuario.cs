using Entities;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public interface IBLUsuario
    {
        Task<Usuario> ObtenerUsuario(string correoElectronico, string contrasenha);
    }
}
