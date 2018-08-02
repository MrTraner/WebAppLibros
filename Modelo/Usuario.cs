using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace WebAppLibros.Modelo
{
    public class Usuario
    {
        private int _IdUsuario;
        private string _Nombre;
        private string _Apellidos;
        private string _Correo;
        private string _Username;
        private string _Password;
        private string _Rol;

        public Usuario()
        {
            this._IdUsuario = 0;
            this._Nombre = "";
            this._Apellidos = "";
            this._Correo = "";
            this._Username = "";
            this._Password = "";
            this._Rol = "";
        }

        public int IdUsuario
        {
            get { return _IdUsuario; }
            set { _IdUsuario = value; }
        }

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        public string Apellidos
        {
            get { return _Apellidos; }
            set { _Apellidos = value; }
        }

        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
        }

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        public string Rol
        {
            get { return _Rol; }
            set { _Rol = value; }
        }
    }
}
