using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebAppLibros.Modelo
{
    /// <summary>
    /// Modelo de la tabla "Libros" de SQL
    /// </summary>
    public class Libro
    {
        //Atributos => Campos de la tabla en SQL
        private int _IdLibro;
        private string _Titulo;
        private string _Autor;
        private string _Descripcion;
        private int _TotalPaginas;
        private double _Precio;

        //Constructor => Inicializar los atributos de la clase
        public Libro()
        {
            this._IdLibro = 0;
            this._Titulo = "";
            this._Autor = "";
            this._Descripcion = "";
            this._TotalPaginas = 0;
            this._Precio = 0;
        }

        //Propiedades => Para asignar un valor a los atributos (set) y obtener su valor (get)
        public int IdLibro
        {
            get { return _IdLibro; }
            set { _IdLibro = value; }
        }

        public string Titulo
        {
            get { return _Titulo; }
            set { _Titulo = value; }
        }

        public string Autor
        {
            get { return _Autor; }
            set { _Autor = value; }
        }

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        public int TotalPaginas
        {
            get { return _TotalPaginas; }
            set { _TotalPaginas = value; }
        }

        public double Precio
        {
            get { return _Precio; }
            set { _Precio = value; }
        }
    }
}
