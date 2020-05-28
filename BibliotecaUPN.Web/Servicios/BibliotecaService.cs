using BibliotecaUPN.Web.Constantes;
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
    public class BibliotecaService: IBibliotecaService
    {
        private AppContext conexion;
        public BibliotecaService()
        {
            this.conexion = new AppContext();
        }
        public Usuario ObtenerUsuarioLogueado()
        {
            return (Usuario)HttpContext.Current.Session["Usuario"];
        }
        public List<Biblioteca> ObteberListaBibliotecas()
        {
            return conexion.Bibliotecas.Include(o => o.Libro.Autor).Include(o => o.Usuario).ToList();
        }
        public void GuardarBiblioteca(Biblioteca biblioteca)
        {
            conexion.Bibliotecas.Add(biblioteca);
            conexion.SaveChanges();
        }
        public void CambiarEstadoLeyendo(Biblioteca libro)
        {
            libro.Estado = ESTADO.LEYENDO;
            conexion.SaveChanges();
        }
        public void CambiarEstadoTerminado(Biblioteca libro)
        {
            libro.Estado = ESTADO.TERMINADO;
            conexion.SaveChanges();
        }
    }
}