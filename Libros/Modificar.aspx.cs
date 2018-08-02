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
    public partial class Modificar : System.Web.UI.Page
    {
        public Libro libro;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params.Get("IdLibro") != null && Request.Params.Get("Titulo") != null && Request.Params.Get("Autor") != null && Request.Params.Get("Descripcion") != null && Request.Params.Get("TotalPaginas") != null && Request.Params.Get("Precio") != null)
            {
                try
                {
                    libro = new Libro();

                    libro.IdLibro = int.Parse(Request.Params.Get("IdLibro"));
                    libro.Titulo = Request.Params.Get("Titulo");
                    libro.Autor = Request.Params.Get("Autor");
                    libro.Descripcion = Request.Params.Get("Descripcion");
                    libro.TotalPaginas = int.Parse(Request.Params.Get("TotalPaginas"));
                    libro.Precio = double.Parse(Request.Params.Get("Precio"));

                    Libro_Acciones libroAccionesObjeto = Libro_Acciones.GetInstancia();
                    libroAccionesObjeto.Modificar(libro);

                    Response.Write("<script>alert('Libro modificado correctamente');</script>");

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
                Response.Write("<script>alert('No se han enviado los campos necesarios');</script>");

                Response.Redirect("ConsultarLibros.aspx");
            }
        }
    }
}
