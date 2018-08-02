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
            Libro libro = new Libro();

            try
            {
                con.Abrir();

                string sql = "select * from Libros where IdLibro = @id";

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@id", id);

                SqlDataReader reader = comando.ExecuteReader();

                while (reader.Read() != null)
                {
                    libro.IdLibro = int.Parse(reader["IdLibro"].ToString());
                    libro.Titulo = reader["Titulo"].ToString();
                    libro.Autor = reader["Autor"].ToString();
                    libro.Descripcion = reader["Descripcion"].ToString();
                    libro.TotalPaginas = int.Parse(reader["TotalPaginas"].ToString());
                    libro.Precio = double.Parse(reader["Precio"].ToString());
                }
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }

            return libro;
        }

        public static int Insertar(Libro libro)
        {
            int resultado = 0;

            try
            {
                con.Abrir();

                string sql = "insert into Libros (Titulo, Autor, Descripcion, TotalPaginas, Precio) values (@titulo, @autor, @descripcion, @totalpaginas, @precio)";

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@titulo", libro.Titulo);
                comando.Parameters.AddWithValue("@autor", libro.Autor);
                comando.Parameters.AddWithValue("@descripcion", libro.Descripcion);
                comando.Parameters.AddWithValue("@totalpaginas", libro.TotalPaginas);
                comando.Parameters.AddWithValue("@precio", libro.Precio);

                resultado = comando.ExecuteNonQuery();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("Error: " + error.ToString());
            }

            return resultado;
        }

        public static int Modificar(Libro libro)
        {
            int resultado = 0;

            try
            {
                con.Abrir();

                string sql = "update Libros set Titulo = @titulo, Autor = @autor, Descripcion = @descripcion, TotalPaginas = @totalpaginas, Precio = @precio where IdLibro = @id";

                SqlCommand comando = new SqlCommand(sql, con.GetConexion());
                comando.Parameters.AddWithValue("@titulo", libro.Titulo);
                comando.Parameters.AddWithValue("@autor", libro.Autor);
                comando.Parameters.AddWithValue("@descripcion", libro.Descripcion);
                comando.Parameters.AddWithValue("@totalpaginas", libro.TotalPaginas);
                comando.Parameters.AddWithValue("@precio", libro.Precio);
                comando.Parameters.AddWithValue("@id", libro.IdLibro);

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

                string sql = "delete from Libros where IdLibro = @id";

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
