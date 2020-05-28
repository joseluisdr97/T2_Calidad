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
    class AuthControllerTest
    {
        [Test]
        public void LoginTest()
        {
            var faker = new Mock<IAuthService>();

            var controller = new AuthController(faker.Object);
            var view = controller.Login();

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void UsuarioNoExisteTest()
        {
            var faker = new Mock<IAuthService>();
            faker.Setup(a => a.ObtenerUsuarios()).Returns(new List<Usuario>
            {
                new Usuario{Id=1,Username="jose@gmail.com", Password="123",Nombres="Jose"},
                new Usuario{Id=1,Username="Luis@gmail.com", Password="1234",Nombres="Luis"}
            });

            var controller = new AuthController(faker.Object);
            var view = controller.Login("juan@gmail.com","321");

            Assert.IsInstanceOf<ViewResult>(view);
        }
        [Test]
        public void UsuarioExisteTest()
        {
            var faker = new Mock<IAuthService>();
            faker.Setup(a => a.ObtenerUsuarios()).Returns(new List<Usuario>
            {
                new Usuario{Id=1,Username="jose@gmail.com", Password="123",Nombres="Jose"},
                new Usuario{Id=1,Username="Luis@gmail.com", Password="1234",Nombres="Luis"}
            });

            var controller = new AuthController(faker.Object);
            var view = controller.Login("jose@gmail.com", "123");

            Assert.IsInstanceOf<RedirectToRouteResult>(view);
        }
    }
}
