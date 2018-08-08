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
    public partial class Eliminar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params.Get("id") != null && Request.Params.Get("id") != "")
            {
                try
                {
                    int id = int.Parse(Request.Params.Get("id"));

                    int resultado = Libro_Acciones.Eliminar(id);

                    if (resultado > 0)
                    {
                        Response.Write("<script>alert('Libro eliminado correctamente');</script>");

                        Response.Redirect("ConsultarLibros.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('No se ha eliminado el libro');</script>");

                        Response.Redirect("ConsultarLibros.aspx");
                    }
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