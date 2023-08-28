using Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Reflection;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAEvento : IDAEvento
    {
        private readonly string _cadenaSQL = "";

        public DAEvento()
        {
            _cadenaSQL = ConfigurationManager.ConnectionStrings["Connection"].ConnectionString;
        }
        public async Task<List<Evento>> ListaEventos()
        {
            var listaEventos = new List<Evento>();
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ListaEventos", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    while (await dr.ReadAsync())
                    {
                        listaEventos.Add(new Evento()
                        {
                            IdEvento = Convert.ToInt32(dr["IdEvento"]),
                            NombreEvento = dr["NombreEvento"].ToString(),
                            Fecha = dr["Fecha"].ToString(),
                            Duracion = Convert.ToInt32(dr["Duracion"]),
                            NroParticipantes = Convert.ToInt32(dr["NroParticipantes"]),
                            NroComisarios = Convert.ToInt32(dr["NroComisarios"]),
                            RefComplejo = new Complejo()
                            {
                                IdComplejo = Convert.ToInt32(dr["IdComplejo"]),
                                NombreComplejo = dr["NombreComplejo"].ToString(),
                            }
                        });
                    }
                }
            }
            return listaEventos;
        }
        public async Task<Evento> ObtenerEvento(int idEvento)
        {
            Evento evento = null;
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_ObtenerEvento", conexion);
                cmd.Parameters.AddWithValue("@IdEvento", idEvento);
                cmd.CommandType = CommandType.StoredProcedure;
                using (var dr = await cmd.ExecuteReaderAsync())
                {
                    if (await dr.ReadAsync())
                    {
                        evento = new Evento()
                        {
                            IdEvento = Convert.ToInt32(dr["IdEvento"]),
                            NombreEvento = dr["NombreEvento"].ToString(),
                            Fecha = dr["Fecha"].ToString(),
                            Duracion = Convert.ToInt32(dr["Duracion"]),
                            NroParticipantes = Convert.ToInt32(dr["NroParticipantes"]),
                            NroComisarios = Convert.ToInt32(dr["NroComisarios"]),
                            RefComplejo = new Complejo()
                            {
                                IdComplejo = Convert.ToInt32(dr["IdComplejo"])
                            }
                        };
                    }
                }
            }
            return evento;
        }
        public async Task<bool> CrearEvento(Evento evento)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_CrearEvento", conexion);
                cmd.Parameters.AddWithValue("@NombreEvento", evento.NombreEvento);
                cmd.Parameters.AddWithValue("@Fecha", evento.Fecha);
                cmd.Parameters.AddWithValue("@Duracion", evento.Duracion);
                cmd.Parameters.AddWithValue("@NroParticipantes", evento.NroParticipantes);
                cmd.Parameters.AddWithValue("@NroComisarios", evento.NroComisarios);
                cmd.Parameters.AddWithValue("@IdComplejo", evento.RefComplejo.IdComplejo);
                cmd.CommandType = CommandType.StoredProcedure;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas > 0)
                    return true;
                else
                    return false;
            }
        }

        public async Task<bool> EditarEvento(Evento evento)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_EditarEvento", conexion);
                cmd.Parameters.AddWithValue("@IdEvento", evento.IdEvento);
                cmd.Parameters.AddWithValue("@NombreEvento", evento.NombreEvento);
                cmd.Parameters.AddWithValue("@Fecha", evento.Fecha);
                cmd.Parameters.AddWithValue("@Duracion", evento.Duracion);
                cmd.Parameters.AddWithValue("@NroParticipantes", evento.NroParticipantes);
                cmd.Parameters.AddWithValue("@NroComisarios", evento.NroComisarios);
                cmd.Parameters.AddWithValue("@IdComplejo", evento.RefComplejo.IdComplejo);
                cmd.CommandType = CommandType.StoredProcedure;

                int filasAfectadas = await cmd.ExecuteNonQueryAsync();

                if (filasAfectadas > 0)
                    return true;
                else
                    return false;
            }
        }
        public async Task<bool> EliminarEvento(int idEvento)
        {
            using (var conexion = new SqlConnection(_cadenaSQL))
            {
                conexion.Open();
                var cmd = new SqlCommand("SP_EliminarEvento", conexion);
                cmd.Parameters.AddWithValue("@IdEvento", idEvento);
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
