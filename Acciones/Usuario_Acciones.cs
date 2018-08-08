using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using MySql.Data;
using MySql.Data.MySqlClient;

using WebAppLibros.BaseDeDatos;
using WebAppLibros.Modelo;

namespace WebAppLibros.Acciones
{
    public class Usuario_Acciones
    {
        private static Conexion con = new Conexion();

        public static Usuario Login(string usr, string pwd)
        {
            Usuario usuario = null;

            try
            {
                con.Abrir();

                string sql = "select * from Usuarios where Username = @usr and Password = @pwd";

                MySqlCommand comando = new MySqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@usr", usr);
                comando.Parameters.AddWithValue("@pwd", pwd);

                MySqlDataReader reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.Apellidos = reader["Apellidos"].ToString();
                    usuario.Correo = reader["Correo"].ToString();
                    usuario.Username = reader["Username"].ToString();
                    usuario.Password = reader["Password"].ToString();
                    usuario.Rol = reader["Rol"].ToString();
                }

                reader.Close();

                con.Cerrar();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }
            finally
            {
                con.Cerrar();
            }

            return usuario;
        }

        public static List<Usuario> Consulta_General()
        {
            List<Usuario> usuarios = new List<Usuario>();

            try
            {
                con.Abrir();

                string sql = "select * from Usuarios";

                MySqlCommand comando = new MySqlCommand(sql, con.GetConexion());

                MySqlDataReader reader = comando.ExecuteReader();

                while(reader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = int.Parse(reader["IdUsuario"].ToString());
                    usuario.Nombre = reader["Nombre"].ToString();
                    usuario.Apellidos = reader["Apellidos"].ToString();
                    usuario.Correo = reader["Correo"].ToString();
                    usuario.Username = reader["Username"].ToString();
                    usuario.Password = reader["Password"].ToString();
                    usuario.Rol = reader["Rol"].ToString();

                    usuarios.Add(usuario);
                }

                reader.Close();

                con.Cerrar();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }
            finally
            {
                con.Cerrar();
            }

            return usuarios;
        }

        public static int Insertar(Usuario usuario)
        {
            int resultado = 0;

            try
            {
                con.Abrir();

                string sql = "insert into Usuarios (Nombre, Apellidos, Correo, Username, Password, Rol) values (@nombre, @apellidos, @correo, @username, @password, @rol)";

                MySqlCommand comando = new MySqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
                comando.Parameters.AddWithValue("@correo", usuario.Correo);
                comando.Parameters.AddWithValue("@username", usuario.Username);
                comando.Parameters.AddWithValue("@password", usuario.Password);
                comando.Parameters.AddWithValue("@rol", usuario.Rol);

                resultado = comando.ExecuteNonQuery();

                con.Cerrar();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }
            finally
            {
                con.Cerrar();
            }

            return resultado;
        }

        public static int Modificar(Usuario usuario)
        {
            int resultado = 0;

            try
            {
                con.Abrir();

                string sql = "update Usuarios set Nombre = @nombre, Apellidos = @apellidos, Correo = @correo, Username = @username, Password = @password, Rol = @rol where IdUsuario = @id";

                MySqlCommand comando = new MySqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
                comando.Parameters.AddWithValue("@correo", usuario.Correo);
                comando.Parameters.AddWithValue("@username", usuario.Username);
                comando.Parameters.AddWithValue("@password", usuario.Password);
                comando.Parameters.AddWithValue("@rol", usuario.Rol);
                comando.Parameters.AddWithValue("@id", usuario.IdUsuario);

                resultado = comando.ExecuteNonQuery();

                con.Cerrar();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }
            finally
            {
                con.Cerrar();
            }

            return resultado;
        }

        public static int Eliminar(int id)
        {
            int resultado = 0;

            try
            {
                con.Abrir();

                string sql = "delete from Usuarios where IdUsuario = @id";

                MySqlCommand comando = new MySqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@id", id);

                resultado = comando.ExecuteNonQuery();

                con.Cerrar();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }
            finally
            {
                con.Cerrar();
            }

            return resultado;
        }
    }
}