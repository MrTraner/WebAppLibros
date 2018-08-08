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
    public partial class InsertarLibro : System.Web.UI.Page
    {
        public string Titulo = "Insertar Libro";

        protected void Page_Load(object sender, EventArgs e)
        {
            btnInsertar.Click += new EventHandler(BtnInsertar_Click);
        }

        private void BtnInsertar_Click(object sender, EventArgs e)
        {
            //Response.Write("<script>alert('Libro insertado');</script>");
            if (Request.Params.Get("Titulo") != "" && Request.Params.Get("Autor") != "" && Request.Params.Get("Descripcion") != "" && Request.Params.Get("TotalPaginas") != "" && Request.Params.Get("Precio") != "")
            {
                try
                {
                    Libro libro = new Libro();
                    libro.Titulo = Request.Params.Get("Titulo");
                    libro.Autor = Request.Params.Get("Autor");
                    libro.Descripcion = Request.Params.Get("Descripcion");
                    libro.TotalPaginas = int.Parse(Request.Params.Get("TotalPaginas"));
                    libro.Precio = double.Parse(Request.Params.Get("Precio"));

                    int resultado = Libro_Acciones.Insertar(libro);

                    if (resultado > 0)
                    {
                        Response.Write("<script>alert('Libro insertado');</script>");

                        Response.Redirect("ConsultarLibros.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('No se ha insertado el libro');</script>");

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
                Response.Write("<script>alert('Se deben llenar todos los campos');</script>");

                Response.Redirect("InsertarLibro.aspx");
            }
        }
    }
}