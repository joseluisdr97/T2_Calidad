using BibliotecaUPN.Web.Constantes;
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
    [Authorize]
    public class BibliotecaController : Controller
    {
        private readonly IBibliotecaService service;
        public BibliotecaController(IBibliotecaService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult Index()
        {
            Usuario user = service.ObtenerUsuarioLogueado();
            var model = service.ObteberListaBibliotecas()
                .Where(o => o.UsuarioId == user.Id)
                .ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult Add(int libro)
        {
            Usuario user = service.ObtenerUsuarioLogueado();

            // TO-DO validar si ya existe el libro en la biblioteca, en ese caso no guardar y notificar

            var biblioteca = new Biblioteca {
                LibroId = libro,
                UsuarioId = user.Id,
                Estado = ESTADO.POR_LEER
            };

            service.GuardarBiblioteca(biblioteca);
       
            TempData["SuccessMessage"] = "Se añádio el libro a su biblioteca";
            ViewBag.SuccessMessage = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult MarcarComoLeyendo(int libroId)
        {

            Usuario user = service.ObtenerUsuarioLogueado();

            // TO-DO validar si ya existe el libro en la biblioteca, en ese caso no guardar y notificar

            var libro = service.ObteberListaBibliotecas()
                .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
                .FirstOrDefault();

            service.CambiarEstadoLeyendo(libro);       

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";
            ViewBag.SuccessMessage = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult MarcarComoTerminado(int libroId)
        {
           
            Usuario user = service.ObtenerUsuarioLogueado();

            // TO-DO validar si ya existe el libro en la biblioteca, en ese caso no guardar y notificar

            var libro = service.ObteberListaBibliotecas()
                .Where(o => o.LibroId == libroId && o.UsuarioId == user.Id)
                .FirstOrDefault();

            service.CambiarEstadoTerminado(libro);

            TempData["SuccessMessage"] = "Se marco como leyendo el libro";
            ViewBag.SuccessMessage = "Se añádio el libro a su biblioteca";

            return RedirectToAction("Index");
        }
    }
}