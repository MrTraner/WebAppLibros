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
    public partial class Eliminar : System.Web.UI.Page
    {
        public Libro libro;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params.Get("id") != null)
            {
                try
                {
                    int id = int.Parse(Request.Params.Get("id"));

                    Libro_Acciones libroAccionesObjeto = Libro_Acciones.GetInstancia();
                    libroAccionesObjeto.Eliminar(id);

                    Response.Write("<script>alert('Libro eliminado correctamente');</script>");

                    Response.Redirect("ConsultarLibros.aspx");
                }
                catch (Exception error)
                {
                    Response.Write("<script>alert('" + error.ToString() + "');</script>");

                    Response.Redirect("ConsultarLibros.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('No se ha enviado el parámetro id');</script>");

                Response.Redirect("ConsultarLibros.aspx");
            }
        }
    }
}
