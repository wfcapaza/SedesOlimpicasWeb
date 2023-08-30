using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAComplejo : IDAComplejo
    {
        private readonly string _cadenaSQL = "";

        public DAComplejo()
        {
            _cadenaSQL = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }
        public async Task<List<Complejo>> ListaComplejos()
        {
            var listaComplejos = new List<Complejo>();
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ListaComplejos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        listaComplejos.Add(new Complejo()
                        {
                            IdComplejo = Convert.ToInt32(dr["IdComplejo"]),
                            NombreComplejo = dr["NombreComplejo"].ToString(),
                            Localizacion = dr["Localizacion"].ToString(),
                            Jefe = dr["Jefe"].ToString(),
                            TipoDeporte = dr["TipoDeporte"].ToString(),
                            AreaOcupada = Convert.ToDecimal(dr["AreaOcupada"]),
                            RefSede = new Sede()
                            {
                                IdSede = Convert.ToInt32(dr["IdSede"]),
                                Nombre = dr["Nombre"].ToString(),
                            }
                        });
                    }
                }
            }
            return listaComplejos;
        }
        public async Task<List<Complejo>> ListaComplejosPorSede(int idSede)
        {
            var listaComplejos = new List<Complejo>();
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ListaComplejosPorSede", conexion);
                cmd.Parameters.AddWithValue("@IdSede", idSede);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        listaComplejos.Add(new Complejo()
                        {
                            IdComplejo = Convert.ToInt32(dr["IdComplejo"]),
                            NombreComplejo = dr["NombreComplejo"].ToString(),
                            RefSede = new Sede()
                            {
                                IdSede = Convert.ToInt32(dr["IdSede"]),
                                Nombre = dr["Nombre"].ToString(),
                            }
                        });
                    }
                }
            }
            return listaComplejos;
        }
        public async Task<Complejo> ObtenerComplejo(int idComplejo)
        {
            Complejo complejo = null;
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ObtenerComplejo", conexion);
                cmd.Parameters.AddWithValue("@IdComplejo", idComplejo);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        complejo = new Complejo()
                        {
                            IdComplejo = Convert.ToInt32(dr["IdComplejo"]),
                            NombreComplejo = dr["NombreComplejo"].ToString(),
                            Localizacion = dr["Localizacion"].ToString(),
                            Jefe = dr["Jefe"].ToString(),
                            TipoDeporte = dr["TipoDeporte"].ToString(),
                            AreaOcupada = Convert.ToDecimal(dr["AreaOcupada"]),
                            RefSede = new Sede()
                            {
                                IdSede = Convert.ToInt32(dr["IdSede"])
                            }
                        };
                    }
                }
            }
            return complejo;
        }
        public async Task<bool> CrearComplejo(Complejo complejo)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_CrearComplejo", conexion);
                cmd.Parameters.AddWithValue("@NombreComplejo", complejo.NombreComplejo);
                cmd.Parameters.AddWithValue("@Localizacion", complejo.Localizacion);
                cmd.Parameters.AddWithValue("@Jefe", complejo.Jefe);
                cmd.Parameters.AddWithValue("@TipoDeporte", complejo.TipoDeporte);
                cmd.Parameters.AddWithValue("@AreaOcupada", complejo.AreaOcupada);
                cmd.Parameters.AddWithValue("@IdSede", complejo.RefSede.IdSede);
                cmd.CommandType = CommandType.StoredProcedure;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas > 0)
                    return true;
                else
                    return false;
            }
        }
        public async Task<bool> EditarComplejo(Complejo complejo)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_EditarComplejo", conexion);
                cmd.Parameters.AddWithValue("@IdComplejo", complejo.IdComplejo);
                cmd.Parameters.AddWithValue("@NombreComplejo", complejo.NombreComplejo);
                cmd.Parameters.AddWithValue("@Localizacion", complejo.Localizacion);
                cmd.Parameters.AddWithValue("@Jefe", complejo.Jefe);
                cmd.Parameters.AddWithValue("@TipoDeporte", complejo.TipoDeporte);
                cmd.Parameters.AddWithValue("@AreaOcupada", complejo.AreaOcupada);
                cmd.Parameters.AddWithValue("@IdSede", complejo.RefSede.IdSede);
                cmd.CommandType = CommandType.StoredProcedure;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas > 0)
                    return true;
                else
                    return false;
            }
        }
        public async Task<bool> EliminarComplejo(int idComplejo)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_EliminarComplejo", conexion);
                cmd.Parameters.AddWithValue("@IdComplejo", idComplejo);
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
