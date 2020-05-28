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
    public class LibroService: ILibroService
    {
        private AppContext conexion;
        public LibroService()
        {
            this.conexion = new AppContext();
        }
        public List<Libro> ObtenerLibros()
        {
            return conexion.Libros.Include(o => o.Autor)
                .Include(o => o.Comentarios.Select(x => x.Usuario)).ToList();
        }
        public Usuario ObtenerUsuarioLogueado()
        {
            return (Usuario)HttpContext.Current.Session["Usuario"];
        }
        public void GuardarComentario(Comentario comentario)
        {
            conexion.Comentarios.Add(comentario);
            conexion.SaveChanges();
        }
        public void GuardarPuntaje(Libro libro, Comentario comentario)
        {
            libro.Puntaje = (libro.Puntaje + comentario.Puntaje) / 2;
            conexion.SaveChanges();
        }
    }
}