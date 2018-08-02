using System;
using System.Collections;
using System.Collections.Generic;
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

using WebAppLibros.Modelo;
using WebAppLibros.Acciones;

namespace WebAppLibros
{
    public partial class _Default : System.Web.UI.Page
    {
        public string Titulo = "Inicio";
        public List<Libro> listaLibros;

        protected void Page_Load(object sender, EventArgs e)
        {
            listaLibros = Libro_Acciones.Consulta_General();
        }
    }
}
