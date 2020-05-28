using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaUPN.Web.Controllers
{
    public class LibroController : Controller
    {
        private readonly ILibroService service;
        public LibroController(ILibroService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult Details(int id)
        {
            var model = service.ObtenerLibros()
                .Where(o => o.Id == id)
                .FirstOrDefault();
            return View(model);
        }

        [HttpPost]
        public ActionResult AddComentario(Comentario comentario)
        {
            // TO-DO validar que el usuario haya terminado de leer el libro para comentar.
            // caso contrario no dejar comentar.

            Usuario user = service.ObtenerUsuarioLogueado();
            comentario.UsuarioId = user.Id;
            comentario.Fecha = DateTime.Now;
            service.GuardarComentario(comentario);           

            var libro = service.ObtenerLibros().Where(o => o.Id == comentario.LibroId).FirstOrDefault();
            service.GuardarPuntaje(libro,comentario);


            return RedirectToAction("Details", new { id = comentario.LibroId });
        }
    }
}