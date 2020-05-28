using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUPN.Web.Interfaces
{
    public interface IAuthService
    {
        List<Usuario> ObtenerUsuarios();
        void GuardarCookie(string username);
        void GuardarUsuario(Usuario usuario);
    }
}
