using _01_Mi_Primera_Vez.Datos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Mi_Primera_Vez.Logica
{
    public class cls_usuarios
    {
        private readonly conexion conexion = new conexion();

        public void InsertarUsuario(dto_usuarios usuario)
        {
            using (SqlConnection conn = conexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_InsertUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cedula", usuario.Cedula);
                cmd.Parameters.AddWithValue("@NombresApellidos", usuario.NombresApellidos);
                cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@Activo", usuario.Activo);
                cmd.Parameters.AddWithValue("@Ciudad", usuario.Ciudad);
                cmd.Parameters.AddWithValue("@IdPais", usuario.IdPais);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void ActualizarUsuario(dto_usuarios usuario)
        {
            using (SqlConnection conn = conexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_UpdateUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Cedula", usuario.Cedula);
                cmd.Parameters.AddWithValue("@NombresApellidos", usuario.NombresApellidos);
                cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@Activo", usuario.Activo);
                cmd.Parameters.AddWithValue("@Ciudad", usuario.Ciudad);
                cmd.Parameters.AddWithValue("@IdPais", usuario.IdPais);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public void EliminarUsuario(int idUsuario)
        {
            using (SqlConnection conn = conexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_DeleteUsuario", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        public List<dto_usuarios> ObtenerUsuarios()
        {
            List<dto_usuarios> listaUsuarios = new List<dto_usuarios>();

            using (SqlConnection conn = conexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_GetUsuarios", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        listaUsuarios.Add(new dto_usuarios
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Cedula = reader["Cedula"].ToString(),
                            NombresApellidos = reader["NombresApellidos"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Activo = Convert.ToBoolean(reader["Activo"]),
                            Ciudad = reader["Ciudad"].ToString(),
                            IdPais = Convert.ToInt32(reader["IdPais"])
                        });
                    }
                }
            }

            return listaUsuarios;
        }

        public dto_usuarios ObtenerUsuarioPorId(int idUsuario)
        {
            dto_usuarios usuario = null;

            using (SqlConnection conn = conexion.obtenerConexion())
            {
                SqlCommand cmd = new SqlCommand("sp_GetUsuarioById", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new dto_usuarios
                        {
                            IdUsuario = Convert.ToInt32(reader["IdUsuario"]),
                            Cedula = reader["Cedula"].ToString(),
                            NombresApellidos = reader["NombresApellidos"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            Activo = Convert.ToBoolean(reader["Activo"]),
                            Ciudad = reader["Ciudad"].ToString(),
                            IdPais = Convert.ToInt32(reader["IdPais"])
                        };
                    }
                }
            }

            return usuario;
        }
    }
}
