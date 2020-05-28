using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BibliotecaUPN.Web.Servicios
{
    public class HomeService: IHomeService
    {
        private AppContext conexion;
        public HomeService()
        {
            this.conexion = new AppContext();
        }
        public List<Libro> ObtenerListLibros()
        {
            return conexion.Libros.Include(o => o.Autor).ToList();
        }
    }
}