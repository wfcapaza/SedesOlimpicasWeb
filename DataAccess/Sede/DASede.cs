using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DASede:IDASede
    {
        private readonly string _cadenaSQL = "";

        public DASede()
        {
            _cadenaSQL = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }
        public async Task<List<Sede>> ListaSedes()
        {
            var listaSedes = new List<Sede>();
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ListaSedes", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        listaSedes.Add(new Sede()
                        {
                            IdSede = Convert.ToInt32(dr["IdSede"]),
                            Nombre = dr["Nombre"].ToString(),
                            NroComplejos = Convert.ToInt32(dr["NroComplejos"]),
                            Presupuesto = Convert.ToDecimal(dr["Presupuesto"])
                        });
                    }
                }
            }
            return listaSedes;
        }
        public async Task<Sede> ObtenerSede(int idSede)
        {
            Sede Sede = null;
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ObtenerSede", conexion);
                cmd.Parameters.AddWithValue("@IdSede", idSede);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        Sede = new Sede()
                        {
                            IdSede = Convert.ToInt32(dr["IdSede"]),
                            Nombre = dr["Nombre"].ToString(),
                            NroComplejos = Convert.ToInt32(dr["NroComplejos"]),
                            Presupuesto = Convert.ToDecimal(dr["Presupuesto"])
                        };
                    }
                }
            }
            return Sede;
        }
        public async Task<bool> CrearSede(Sede sede)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_CrearSede", conexion);
                cmd.Parameters.AddWithValue("@Nombre", sede.Nombre);
                cmd.Parameters.AddWithValue("@NroComplejos", sede.NroComplejos);
                cmd.Parameters.AddWithValue("@Presupuesto", sede.Presupuesto);
                cmd.CommandType = CommandType.StoredProcedure;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> EditarSede(Sede sede)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_EditarSede", conexion);
                cmd.Parameters.AddWithValue("@IdSede", sede.IdSede);
                cmd.Parameters.AddWithValue("@Nombre", sede.Nombre);
                cmd.CommandType = CommandType.StoredProcedure;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas > 0)
                    return true;
                else
                    return false;
            }
        }
        public async Task<bool> EliminarSede(int idSede)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_EliminarSede", conexion);
                cmd.Parameters.AddWithValue("@IdSede", idSede);
                cmd.CommandType = CommandType.StoredProcedure;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
