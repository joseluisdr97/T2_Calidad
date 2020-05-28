using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BibliotecaUPN.Web.Servicios
{
    public class AuthService:IAuthService
    {
        private AppContext conexion;
        public AuthService()
        {
            this.conexion = new AppContext();
        }
        public List<Usuario> ObtenerUsuarios()
        {
            return conexion.Usuarios.ToList();
        }
        public void GuardarCookie(string username)
        {
            FormsAuthentication.SetAuthCookie(username, false);
        }
        public void GuardarUsuario(Usuario usuario)
        {
            HttpContext.Current.Session["Usuario"] = usuario;
        }
    }
}