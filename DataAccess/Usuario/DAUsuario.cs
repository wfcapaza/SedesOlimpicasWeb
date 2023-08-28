using Entities;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAUsuario: IDAUsuario
    {
        private readonly string _cadenaSQL = "";

        public DAUsuario()
        {
            _cadenaSQL = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }
        public async Task<Usuario> ObtenerUsuario(string correoElectronico, string contrasenha)
        {
            Usuario usuario = null;
            SqlConnectionStringBuilder build = new SqlConnectionStringBuilder(_cadenaSQL);
            using (var conexion = new SqlConnection(build.ConnectionString))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ObtenerUsuario", conexion);
                cmd.Parameters.AddWithValue("@CorreoElectronico", correoElectronico);
                cmd.Parameters.AddWithValue("@Contrasenha", contrasenha);
                cmd.CommandType = CommandType.StoredProcedure;                
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if(await dr.ReadAsync())
                    {
                        usuario = new Usuario()
                        {
                            IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                            CorreoElectronico = dr["CorreoElectronico"].ToString(),
                            Contrasenha = dr["Contrasenha"].ToString()
                        };
                    }
                }
            }
            return usuario;
        }
        public Task<bool> CrearUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }        
    }
}
