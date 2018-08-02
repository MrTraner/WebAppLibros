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
    public partial class InsertarLibro : System.Web.UI.Page
    {
        public string Titulo = "Insertar Libro";

        protected void Page_Load(object sender, EventArgs e)
        {
            btnInsertar.Click += new EventHandler(btnInsertar_Click);
        }

        void btnInsertar_Click(object sender, EventArgs e)
        {
            Response.Write("<script>alert('Libro insertado');</script>");
            if (Request.Params.Get("Titulo") != "" && Request.Params.Get("Autor") != "" && Request.Params.Get("Descripcion") != "" && Request.Params.Get("TotalPaginas") != "" && Request.Params.Get("Precio") != "")
            {
                try
                {
                    Libro_Acciones libroAccionesObjeto = Libro_Acciones.GetInstancia();

                    Libro libro = new Libro();

                    libro.IdLibro = libroAccionesObjeto.Consulta_General().Count + 1;
                    libro.Titulo = Request.Params.Get("Titulo");
                    libro.Autor = Request.Params.Get("Autor");
                    libro.Descripcion = Request.Params.Get("Descripcion");
                    libro.TotalPaginas = int.Parse(Request.Params.Get("TotalPaginas"));
                    libro.Precio = double.Parse(Request.Params.Get("Precio"));

                    libroAccionesObjeto.Insertar(libro);

                    Response.Write("<script>alert('Libro insertado');</script>");

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
                Response.Write("<script>alert('Se deben llenar todos los campos');</script>");

                Response.Redirect("InsertarLibro.aspx");
            }
        }
    }
}
