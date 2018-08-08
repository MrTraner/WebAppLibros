using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebAppLibros.Modelo;
using WebAppLibros.Acciones;

namespace WebAppLibros.Cuenta
{
    public partial class Perfil : System.Web.UI.Page
    {
        public string Titulo = "Perfil";
        public Usuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            usuario = (Usuario)Session["usuario"];

            btnModificar.Click += new EventHandler(BtnModificar_Click);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (Request.Params.Get("Nombre") != "" && Request.Params.Get("Apellidos") != "" && Request.Params.Get("Correo") != "" && Request.Params.Get("Username") != "" && Request.Params.Get("Password") != "")
            {
                try
                {
                    usuario.Nombre = Request.Params.Get("Nombre");
                    usuario.Apellidos = Request.Params.Get("Apellidos");
                    usuario.Correo = Request.Params.Get("Correo");
                    usuario.Username = Request.Params.Get("Username");
                    usuario.Password = Request.Params.Get("Password");

                    int resultado = Usuario_Acciones.Modificar(usuario);

                    if (resultado > 0)
                    {
                        Response.Write("<script>alert('Usuario modificado');</script>");

                        Response.Redirect("../Default.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('No se ha modificado el usuario');</script>");

                        Response.Redirect("../Default.aspx");
                    }
                }
                catch (Exception error)
                {
                    Response.Write("<script>alert('" + error.ToString() + "');</script>");

                    Response.Redirect("../Default.aspx");
                }
            }
            else
            {
                Response.Write("<script>alert('Se deben llenar todos los campos');</script>");

                Response.Redirect("Perfil.aspx");
            }
        }
    }
}