using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUPN.Web.Interfaces
{
    public interface ILibroService
    {
        List<Libro> ObtenerLibros();
        Usuario ObtenerUsuarioLogueado();
        void GuardarComentario(Comentario comentario);
        void GuardarPuntaje(Libro libro, Comentario comentario);
    }
}
