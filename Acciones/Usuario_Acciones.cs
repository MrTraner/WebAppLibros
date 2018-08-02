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
    }
}
