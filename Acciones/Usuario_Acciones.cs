using System;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections;
using System.Collections.Generic;
using WebAppLibros.Modelo;
using WebAppLibros.BaseDeDatos;
using System.Data;
using System.Data.SqlClient;

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

                string sentenciaSQL = "select * from Usuarios where Username = @user and Password = @pass";

                SqlCommand comando = new SqlCommand(sentenciaSQL, con.GetConexion());

                comando.Parameters.AddWithValue("@user", usr);
                comando.Parameters.AddWithValue("@pass", pwd);

                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    usuario = new Usuario();
                    usuario.IdUsuario = int.Parse(dataReader["IdUsuario"].ToString());
                    usuario.Nombre = dataReader["Nombre"].ToString();
                    usuario.Apellidos = dataReader["Apellidos"].ToString();
                    usuario.Correo = dataReader["Correo"].ToString();
                    usuario.Username = dataReader["Username"].ToString();
                    usuario.Password = dataReader["Password"].ToString();
                    usuario.Rol = dataReader["Rol"].ToString();
                }

                dataReader.Close();

                con.Cerrar();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return usuario;
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

                string sentenciaSQL = "select * from Usuarios";
                SqlCommand comando = new SqlCommand(sentenciaSQL, con.GetConexion());

                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.IdUsuario = int.Parse(dataReader["IdUsuario"].ToString());
                    usuario.Nombre = dataReader["Nombre"].ToString();
                    usuario.Apellidos = dataReader["Apellidos"].ToString();
                    usuario.Correo = dataReader["Correo"].ToString();
                    usuario.Username = dataReader["Username"].ToString();
                    usuario.Password = dataReader["Password"].ToString();
                    usuario.Rol = dataReader["Rol"].ToString();

                    usuarios.Add(usuario);
                }

                dataReader.Close();

                con.Cerrar();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return usuarios;
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

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
                comando.Parameters.AddWithValue("@correo", usuario.Correo);
                comando.Parameters.AddWithValue("@username", usuario.Username);
                comando.Parameters.AddWithValue("@password", usuario.Password);
                comando.Parameters.AddWithValue("@rol", usuario.Rol);

                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
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

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@nombre", usuario.Nombre);
                comando.Parameters.AddWithValue("@apellidos", usuario.Apellidos);
                comando.Parameters.AddWithValue("@correo", usuario.Correo);
                comando.Parameters.AddWithValue("@username", usuario.Username);
                comando.Parameters.AddWithValue("@password", usuario.Password);
                comando.Parameters.AddWithValue("@rol", usuario.Rol);
                comando.Parameters.AddWithValue("@id", usuario.IdUsuario);

                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
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

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@id", id);

                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }

            return resultado;
        }
    }
}
