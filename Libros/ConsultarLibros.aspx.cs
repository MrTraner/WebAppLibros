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
    public partial class ConsultarLibros : System.Web.UI.Page
    {
        public string Titulo = "Consultar Libros";
        public List<Libro> listaLibros;
        public Usuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            listaLibros = Libro_Acciones.Consulta_General();
            usuario = (Usuario)Session["usuario"];
        }
    }
}