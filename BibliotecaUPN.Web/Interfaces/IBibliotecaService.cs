using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUPN.Web.Interfaces
{
    public interface IBibliotecaService
    {
        Usuario ObtenerUsuarioLogueado();
        List<Biblioteca> ObteberListaBibliotecas();
        void GuardarBiblioteca(Biblioteca biblioteca);
        void CambiarEstadoLeyendo(Biblioteca libro);
        void CambiarEstadoTerminado(Biblioteca libro);
    }
}
