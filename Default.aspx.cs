using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebAppLibros.Modelo;
using WebAppLibros.Acciones;

namespace WebAppLibros
{
    public partial class Default : System.Web.UI.Page
    {
        public string Titulo = "Inicio";
        public List<Libro> listaLibros;

        protected void Page_Load(object sender, EventArgs e)
        {
            listaLibros = Libro_Acciones.Consulta_General();
        }
    }
}