using DataAccess;
using Entities;
using System.Threading.Tasks;

namespace BusinessLogic
{
    public class BLUsuario : IBLUsuario
    {
        private readonly IDAUsuario _usuario;
        public BLUsuario(IDAUsuario usuario)
        {
            _usuario = usuario;
        }
        public async Task<Usuario> ObtenerUsuario(string correoElectronico, string contrasenha)
        {
            return await _usuario.ObtenerUsuario(correoElectronico, contrasenha);
        }
    }
}
