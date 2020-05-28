using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BibliotecaUPN.Web.Controllers
{

    [Authorize]
    public class HomeController : Controller
    {
        private readonly IHomeService service;
        public HomeController(IHomeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public ActionResult Index()
        { 
            var model = service.ObtenerListLibros().ToList();
            return View(model);
        }       

    }
}