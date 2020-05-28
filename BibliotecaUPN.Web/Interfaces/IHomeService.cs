using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaUPN.Web.Interfaces
{
    public interface IHomeService
    {
        List<Libro> ObtenerListLibros();
    }
}
