using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using WebAppLibros.Modelo;
using WebAppLibros.Acciones;

namespace WebAppLibros.Acceso
{
    public partial class Registro : System.Web.UI.Page
    {
        public string Titulo = "Regístrate";

        protected void Page_Load(object sender, EventArgs e)
        {
            btnRegistrar.Click += new EventHandler(BtnModificar_Click);
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (Request.Params.Get("Nombre") != "" && Request.Params.Get("Apellidos") != "" && Request.Params.Get("Correo") != "" && Request.Params.Get("Username") != "" && Request.Params.Get("Password") != "")
            {
                try
                {
                    Usuario usuario = new Usuario();
                    usuario.Nombre = Request.Params.Get("Nombre");
                    usuario.Apellidos = Request.Params.Get("Apellidos");
                    usuario.Correo = Request.Params.Get("Correo");
                    usuario.Username = Request.Params.Get("Username");
                    usuario.Password = Request.Params.Get("Password");
                    usuario.Rol = "USER";

                    int resultado = Usuario_Acciones.Insertar(usuario);

                    if (resultado > 0)
                    {
                        Response.Write("<script>alert('Usuario insertado');</script>");

                        Response.Redirect("../Default.aspx");
                    }
                    else
                    {
                        Response.Write("<script>alert('No se ha insertado el usuario');</script>");

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