using System;

using System.Data;
using System.Data.SqlClient;

namespace WebAppLibros.BaseDeDatos
{
    public class Conexion
    {
        //SQL Server
        private SqlConnection Con;
        private string NombreServidor = ".";
        private string NombreBaseDeDatos = "Ejemplo";
        private string DatosConexion;

        public Conexion()
        {
            DatosConexion = "Data Source=" + NombreServidor + ";Initial Catalog=" + NombreBaseDeDatos + ";Integrated Security=True;";
            Con = new SqlConnection(DatosConexion);
        }

        public void Abrir()
        {
            Con.Open();
        }

        public void Cerrar()
        {
            Con.Close();
        }

        public SqlConnection GetConexion()
        {
            return Con;
        }
    }
}
