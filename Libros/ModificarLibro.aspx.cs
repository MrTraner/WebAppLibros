using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using WebAppLibros.Acciones;
using WebAppLibros.Modelo;

namespace WebAppLibros.Libros
{
    public partial class ModificarLibro : System.Web.UI.Page
    {
        public string Titulo = "Modificar Libro";
        public Libro libro;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Get("id") != null)
            {
                try
                {
                    int IdLibro = int.Parse(Request.QueryString.Get("id"));

                    Libro_Acciones libroAccionesObjeto = Libro_Acciones.GetInstancia();
                    libro = libroAccionesObjeto.Consultar_Id(IdLibro);
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
