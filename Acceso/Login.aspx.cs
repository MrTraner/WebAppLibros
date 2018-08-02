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

using WebAppLibros.Acciones;
using WebAppLibros.Modelo;

namespace WebAppLibros.Acceso
{
    public partial class Login : System.Web.UI.Page
    {
        public string Titulo = "Login";

        protected void Page_Load(object sender, EventArgs e)
        {
            //Usuario_Acciones usuarioAccionesObjeto = Usuario_Acciones.GetInstancia();

            if (Request.Params.Get("Usuario") != null && Request.Params.Get("Contraseña") != null)
            {
                string username = Request.Params.Get("Usuario");
                string password = Request.Params.Get("Contraseña");

                Response.Write("<script>alert('se ha enviado el formulario por post');</script>");
                Response.Write("<script>alert('datos recibidos: " + username + ", " + password + "');</script>");

                //Usuario usuario = usuarioAccionesObjeto.Login(username, password);
                Usuario usuario = Usuario_Acciones.Login(username, password);

                if (usuario != null)
                {
                    Response.Write("<script>alert('usuario y contraseña correctos');</script>");

                    Session.Add("usuario", usuario);
                }
                else
                {
                    Response.Write("<script>alert('usuario o contraseña incorrectos');</script>");
                }
            }
        }
    }
}
