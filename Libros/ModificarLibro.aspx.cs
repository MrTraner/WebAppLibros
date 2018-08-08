using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebAppLibros.Modelo;
using WebAppLibros.Acciones;

namespace WebAppLibros.Libros
{
    public partial class ModificarLibro : System.Web.UI.Page
    {
        public string Titulo = "Modificar Libro";
        public Libro libro;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("id") != null && Request.QueryString.Get("id") != "")
            {
                try
                {
                    int IdLibro = int.Parse(Request.QueryString.Get("id"));

                    libro = Libro_Acciones.Consultar_Id(IdLibro);
                }
                catch (Exception error)
                {
                    Response.Write("<script>alert('El IdLibro no existe');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('El IdLibro no se ha especificado');</script>");
            }
        }
    }
}