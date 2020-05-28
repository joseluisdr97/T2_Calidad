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
    class LibroControllerTest
    {
        [Test]
        public void BuscarLibro_DetailsTest()
        {
            var faker = new Mock<ILibroService>();
            faker.Setup(a => a.ObtenerUsuarioLogueado()).Returns(new Usuario { Id = 1, Username = "jose@gmail.com", Password = "123", Nombres = "Jose" });
            faker.Setup(a => a.ObtenerLibros()).Returns(new List<Libro>
            {
                new Libro{Id=1,Nombre="La primera guerraMundial",AutorId=1, Imagen=""},
                new Libro{Id=2,Nombre="La primera segunda",AutorId=2, Imagen=""},
                new Libro{Id=3,Nombre="La primera tercera",AutorId=3, Imagen=""}
            });

            var controller = new LibroController(faker.Object);
            var view = controller.Details(1) as ViewResult;
            var model = view.Model as Libro;
            Assert.AreEqual(1, model.AutorId);
        }
        [Test]
        public void Return_DetailsTest()
        {

            var faker = new Mock<ILibroService>();
            faker.Setup(a => a.ObtenerLibros()).Returns(new List<Libro>
            {
            });

            var controller = new LibroController(faker.Object);
            var view = controller.Details(1) as ViewResult;
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void ReturnUsuario_DetailsTest()
        {
            var faker = new Mock<ILibroService>();
            faker.Setup(a => a.ObtenerLibros()).Returns(new List<Libro>
            {
                                new Libro{Id=1,Nombre="La primera guerraMundial",AutorId=1, Imagen=""},
                new Libro{Id=2,Nombre="La primera segunda",AutorId=2, Imagen=""},
                new Libro{Id=3,Nombre="La primera tercera",AutorId=3, Imagen=""}
            });

            var controller = new LibroController(faker.Object);
            var view = controller.Details(1) as ViewResult;
            Assert.IsInstanceOf<Libro>(view.Model);
        }
        [Test]
        public void ReturnComentario_DetailsTest()
        {
            var comentario = new Comentario { Id = 1, UsuarioId = 1, LibroId = 1, Texto = "" };
            var faker = new Mock<ILibroService>();
            faker.Setup(a => a.ObtenerUsuarioLogueado()).Returns(new Usuario { Id = 1, Username = "jose@gmail.com", Password = "123", Nombres = "Jose" });
            faker.Setup(a => a.ObtenerLibros()).Returns(new List<Libro>
            {
                                new Libro{Id=1,Nombre="La primera guerraMundial",AutorId=1, Imagen=""},
                new Libro{Id=2,Nombre="La primera segunda",AutorId=2, Imagen=""},
                new Libro{Id=3,Nombre="La primera tercera",AutorId=3, Imagen=""}
            });

            var controller = new LibroController(faker.Object);
            var view = controller.AddComentario(comentario);
            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
    }
}
