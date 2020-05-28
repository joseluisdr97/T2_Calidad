using BibliotecaUPN.Web.DB;
using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace BibliotecaUPN.Web.Controllers
{
    public class AuthController : Controller
    {

        private readonly IAuthService service;
        public AuthController(IAuthService service)
        {
            this.service = service;
        }
        [HttpGet]
        public ActionResult Login()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {

            var usuario = service.ObtenerUsuarios().Where(o => o.Username == username && o.Password == password).FirstOrDefault();
            if (usuario != null)
            {
                service.GuardarCookie(username);
                     service.GuardarUsuario(usuario);
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Validation = "Usuario y/o contraseña incorrecta";
            return View();
        }

        public ActionResult Logout() {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
    }
}