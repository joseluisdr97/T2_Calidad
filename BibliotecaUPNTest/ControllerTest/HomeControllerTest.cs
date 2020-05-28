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
    class HomeControllerTest
    {
        [Test]
        public void ContarLibrosIndex()
        {
            var faker = new Mock<IHomeService>();
            faker.Setup(a => a.ObtenerListLibros()).Returns(new List<Libro>
            {
                new Libro{Id=1,Nombre="La primera guerraMundial",AutorId=1, Imagen=""},
                new Libro{Id=2,Nombre="La primera segunda",AutorId=2, Imagen=""},
                new Libro{Id=3,Nombre="La primera tercera",AutorId=3, Imagen=""}
            });

            var controller = new HomeController(faker.Object);
            var view = controller.Index() as ViewResult;
            var model = view.Model as List<Libro>;
            Assert.AreEqual(3, model.Count);
        }
        [Test]
        public void ReturnIndex()
        {
            var faker = new Mock<IHomeService>();
            faker.Setup(a => a.ObtenerListLibros()).Returns(new List<Libro>
            {
                new Libro{Id=1,Nombre="La primera guerraMundial",AutorId=1, Imagen=""},
                new Libro{Id=2,Nombre="La primera segunda",AutorId=2, Imagen=""},
                new Libro{Id=3,Nombre="La primera tercera",AutorId=3, Imagen=""}
            });

            var controller = new HomeController(faker.Object);
            var view = controller.Index() as ViewResult;
            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void BuscarElementoIndex()
        {
            var faker = new Mock<IHomeService>();
            faker.Setup(a => a.ObtenerListLibros()).Returns(new List<Libro>
            {
                new Libro{Id=1,Nombre="La primera guerraMundial",AutorId=1, Imagen=""},
                new Libro{Id=2,Nombre="La primera segunda",AutorId=2, Imagen=""},
                new Libro{Id=3,Nombre="La primera tercera",AutorId=3, Imagen=""}
            });

            var controller = new HomeController(faker.Object);
            var view = controller.Index() as ViewResult;
            var model = view.Model as List<Libro>;
            Assert.AreEqual("La primera guerraMundial", model[0].Nombre);
        }
    }
}
