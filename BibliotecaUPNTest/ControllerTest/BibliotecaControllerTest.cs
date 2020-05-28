using BibliotecaUPN.Web.Controllers;
using BibliotecaUPN.Web.Interfaces;
using BibliotecaUPN.Web.Models;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BibliotecaUPNTest.ControllerTest
{
    [TestFixture]
    class BibliotecaControllerTest
    {
        [Test]
        public void ContarBibliotecasDeUnUsuarioTest()
        {

            var faker = new Mock<IBibliotecaService>();
            faker.Setup(a => a.ObtenerUsuarioLogueado()).Returns(new Usuario { Id = 1, Username = "jose@gmail.com", Password = "123", Nombres = "Jose" });
            faker.Setup(a => a.ObteberListaBibliotecas()).Returns(new List<Biblioteca>
            {
                new Biblioteca{Id=1,UsuarioId=1, LibroId=1},
                new Biblioteca{Id=2,UsuarioId=1, LibroId=2},
                new Biblioteca{Id=3,UsuarioId=3, LibroId=3}
            });

            var controller = new BibliotecaController(faker.Object);
            var view = controller.Index() as ViewResult;
            var model = view.Model as List<Biblioteca>;
            Assert.AreEqual(2, model.Count);
        }
        [Test]
        public void ReturnsIndexTest()
        {

            var faker = new Mock<IBibliotecaService>();
            faker.Setup(a => a.ObtenerUsuarioLogueado()).Returns(new Usuario { Id = 1, Username = "jose@gmail.com", Password = "123", Nombres = "Jose" });
            faker.Setup(a => a.ObteberListaBibliotecas()).Returns(new List<Biblioteca>
            {
                new Biblioteca{Id=1,UsuarioId=1, LibroId=1},
                new Biblioteca{Id=2,UsuarioId=1, LibroId=2},
                new Biblioteca{Id=3,UsuarioId=3, LibroId=3}
            });

            var controller = new BibliotecaController(faker.Object);
            var view = controller.Index();
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void ReturnsIndexModelTest()
        {

            var faker = new Mock<IBibliotecaService>();
            faker.Setup(a => a.ObtenerUsuarioLogueado()).Returns(new Usuario { Id = 1, Username = "jose@gmail.com", Password = "123", Nombres = "Jose" });
            faker.Setup(a => a.ObteberListaBibliotecas()).Returns(new List<Biblioteca>
            {
                new Biblioteca{Id=1,UsuarioId=1, LibroId=1},
                new Biblioteca{Id=2,UsuarioId=1, LibroId=2},
                new Biblioteca{Id=3,UsuarioId=3, LibroId=3}
            });

            var controller = new BibliotecaController(faker.Object);
            var view = controller.Index() as ViewResult;
            Assert.IsInstanceOf<List<Biblioteca>>(view.Model);
        }
        [Test]
        public void ReturnsAddTest()
        {

            var faker = new Mock<IBibliotecaService>();
            faker.Setup(a => a.ObtenerUsuarioLogueado()).Returns(new Usuario { Id = 1, Username = "jose@gmail.com", Password = "123", Nombres = "Jose" });

            var controller = new BibliotecaController(faker.Object);
            var view = controller.Add(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
        //[Test]
        //public void ReturnsAddTempDataTest()
        //{
        //    var faker = new Mock<IBibliotecaService>();
        //    faker.Setup(a => a.ObtenerUsuarioLogueado()).Returns(new Usuario { Id = 1, Username = "jose@gmail.com", Password = "123", Nombres = "Jose" });

        //    var controller = new BibliotecaController(faker.Object);
        //    var view = controller.Add(1) as ViewResult;
        //    Assert.AreEqual("Se añádio el libro a su biblioteca", view.TempData["SuccessMessage"]);
        //}
        [Test]
        public void ReturnsMarcarComoLeyendolTest()
        {

            var faker = new Mock<IBibliotecaService>();
            faker.Setup(a => a.ObtenerUsuarioLogueado()).Returns(new Usuario { Id = 1, Username = "jose@gmail.com", Password = "123", Nombres = "Jose" });
            faker.Setup(a => a.ObteberListaBibliotecas()).Returns(new List<Biblioteca>
            {
                new Biblioteca{Id=1,UsuarioId=1, LibroId=1},
                new Biblioteca{Id=2,UsuarioId=1, LibroId=2},
                new Biblioteca{Id=3,UsuarioId=3, LibroId=3}
            });

            var controller = new BibliotecaController(faker.Object);
            var view = controller.MarcarComoLeyendo(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
        [Test]
        public void ReturnsMarcarComoTerminadoTest()
        {
            var faker = new Mock<IBibliotecaService>();
            faker.Setup(a => a.ObtenerUsuarioLogueado()).Returns(new Usuario { Id = 1, Username = "jose@gmail.com", Password = "123", Nombres = "Jose" });
            faker.Setup(a => a.ObteberListaBibliotecas()).Returns(new List<Biblioteca>
            {
                new Biblioteca{Id=1,UsuarioId=1, LibroId=1},
                new Biblioteca{Id=2,UsuarioId=1, LibroId=2},
                new Biblioteca{Id=3,UsuarioId=3, LibroId=3}
            });

            var controller = new BibliotecaController(faker.Object);
            var view = controller.MarcarComoTerminado(1);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
        [Test]
        public void BuscarLibroDeUnUsuarioTest()
        {

            var faker = new Mock<IBibliotecaService>();
            faker.Setup(a => a.ObtenerUsuarioLogueado()).Returns(new Usuario { Id = 1, Username = "jose@gmail.com", Password = "123", Nombres = "Jose" });
            faker.Setup(a => a.ObteberListaBibliotecas()).Returns(new List<Biblioteca>
            {
                new Biblioteca{Id=1,UsuarioId=1, LibroId=1},
                new Biblioteca{Id=2,UsuarioId=1, LibroId=2},
                new Biblioteca{Id=3,UsuarioId=3, LibroId=3}
            });

            var controller = new BibliotecaController(faker.Object);
            var view = controller.Index() as ViewResult;
            var model = view.Model as List<Biblioteca>;
            Assert.AreEqual(2, model[1].LibroId);
        }
    }
}
