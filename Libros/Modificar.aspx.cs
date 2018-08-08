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
    public partial class Modificar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Params.Get("IdLibro") != null && Request.Params.Get("Titulo") != null && Request.Params.Get("Autor") != null && Request.Params.Get("Descripcion") != null && Request.Params.Get("TotalPaginas") != null && Request.Params.Get("Precio") != null)
            {
                try
                {
                    Libro libro = new Libro();

                    libro.IdLibro = int.Parse(Request.Params.Get("IdLibro"));
                    libro.Titulo = Request.Params.Get("Titulo");
                    libro.Autor = Request.Params.Get("Autor");
                    libro.Descripcion = Request.Params.Get("Descripcion");
                    libro.TotalPaginas = int.Parse(Request.Params.Get("TotalPaginas"));
                    libro.Precio = double.Parse(Request.Params.Get("Precio"));

                    int resultado = Libro_Acciones.Modificar(libro);

                    if (resultado > 0)
                    {
                        Response.Write("<script>alert('Libro modificado correctamente');</script>");

                        Response.Redirect("ConsultarLibros.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('No se ha modificado el libro');</script>");

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
                Response.Write("<script>alert('No se han enviado los campos necesarios');</script>");

                Response.Redirect("ConsultarLibros.aspx");
            }
        }
    }
}