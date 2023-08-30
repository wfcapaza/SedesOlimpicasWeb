using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAComisario : IDAComisario
    {
        private readonly string _cadenaSQL = "";

        public DAComisario()
        {
            _cadenaSQL = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }
        public async Task<List<Comisario>> ListaComisarios()
        {
            var listaComisarios = new List<Comisario>();
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ListaComisarios", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        listaComisarios.Add(new Comisario()
                        {
                            IdComisario = Convert.ToInt32(dr["IdComisario"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            TipoTarea = dr["TipoTarea"].ToString(),
                            RefEvento = new Evento()
                            {
                                IdEvento = Convert.ToInt32(dr["IdEvento"]),
                                NombreEvento = dr["NombreEvento"].ToString(),
                            }
                        });
                    }
                }
            }
            return listaComisarios;
        }

        public async Task<Comisario> ObtenerComisario(int idComisario)
        {
            Comisario comisario = null;
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ObtenerComisario", conexion);
                cmd.Parameters.AddWithValue("@IdComisario", idComisario);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        comisario = new Comisario()
                        {
                            IdComisario = Convert.ToInt32(dr["IdComisario"]),
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            TipoTarea = dr["TipoTarea"].ToString(),
                            RefEvento = new Evento()
                            {
                                IdEvento = Convert.ToInt32(dr["IdEvento"])
                            }
                        };
                    }
                }
            }
            return comisario;
        }
        public async Task<bool> CrearComisario(Comisario comisario)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_CrearComisario", conexion);
                cmd.Parameters.AddWithValue("@Nombres", comisario.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", comisario.Apellidos);
                cmd.Parameters.AddWithValue("@TipoTarea", comisario.TipoTarea);
                cmd.Parameters.AddWithValue("@IdEvento", comisario.RefEvento.IdEvento);
                cmd.CommandType = CommandType.StoredProcedure;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> EditarComisario(Comisario comisario)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_EditarComisario", conexion);
                cmd.Parameters.AddWithValue("@IdComisario", comisario.IdComisario);
                cmd.Parameters.AddWithValue("@Nombres", comisario.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", comisario.Apellidos);
                cmd.Parameters.AddWithValue("@TipoTarea", comisario.TipoTarea);
                cmd.Parameters.AddWithValue("@IdEvento", comisario.RefEvento.IdEvento);
                cmd.CommandType = CommandType.StoredProcedure;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> EliminarComisario(int idComisario)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_EliminarComisario", conexion);
                cmd.Parameters.AddWithValue("@IdComisario", idComisario);
                cmd.CommandType = CommandType.StoredProcedure;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas > 0)
                    return true;
                else
                    return false;
            }
        }
        public async Task<List<Comisario>> ListaSedeConComisario()
        {
            var listaSedeConComisario = new List<Comisario>();
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ListaSedeConComisario", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        listaSedeConComisario.Add(new Comisario()
                        {
                            Nombres = dr["Nombres"].ToString(),
                            Apellidos = dr["Apellidos"].ToString(),
                            TipoTarea = dr["TipoTarea"].ToString(),
                            RefEvento = new Evento()
                            {
                                NombreEvento = dr["NombreEvento"].ToString(),
                                Fecha = dr["Fecha"].ToString(),
                                RefComplejo = new Complejo()
                                {
                                    NombreComplejo = dr["NombreComplejo"].ToString(),
                                    TipoDeporte = dr["TipoDeporte"].ToString(),
                                    RefSede = new Sede()
                                    {
                                        Nombre = dr["Nombre"].ToString(),
                                        Presupuesto = Convert.ToDecimal(dr["Presupuesto"])
                                    }
                                }
                            }
                        });
                    }
                }
            }
            return listaSedeConComisario;
        }
    }
}
