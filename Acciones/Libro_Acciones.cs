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
    public class Libro_Acciones
    {
        private static Conexion con = new Conexion();

        public static List<Libro> Consulta_General() {
            List<Libro> libros = new List<Libro>();

            try
            {
                con.Abrir();

                string sentenciaSQL = "select * from Libros";
                SqlCommand comando = new SqlCommand(sentenciaSQL, con.GetConexion());

                SqlDataReader dataReader = comando.ExecuteReader();

                while (dataReader.Read())
                {
                    Libro libro = new Libro();
                    libro.IdLibro = int.Parse(dataReader["IdUsuario"].ToString());
                    libro.Titulo = dataReader["Nombre"].ToString();
                    libro.Autor = dataReader["Apellidos"].ToString();
                    libro.Descripcion = dataReader["Correo"].ToString();
                    libro.TotalPaginas = int.Parse(dataReader["Username"].ToString());
                    libro.Precio = double.Parse(dataReader["Password"].ToString());

                    libros.Add(libro);
                }

                dataReader.Close();

                con.Cerrar();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                return libros;
            }
            finally
            {
                con.Cerrar();
            }

            return libros;
        }

        public static Libro Consultar_Id(int id)
        {
            return null;
        }

        public static void Insertar(Libro libro)
        {
            
        }

        public static void Modificar(Libro libro)
        {

        }

        public static void Eliminar(Libro libro)
        {

        }
    }
}
