using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BibliotecaUPNTest.PruebasSelenium
{
    [TestFixture]
    class Pruebas
    {
        [Test]
        public void VerificarQueNoIngresoLogin()
        {
            IWebDriver navegador = new ChromeDriver();

            navegador.Url = "http://localhost:58972/Auth/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#user"));
            input1Busqueda.SendKeys("admin@gmail.com");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#pass"));
            input2Busqueda.SendKeys("administrador");

            var boton = navegador.FindElement(By.CssSelector("#ingresar"));
            boton.Click();
            var buscarId = navegador.FindElement(By.CssSelector("#EstoyEnLogin"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
        [Test]
        public void VerificarQueIngresoLogin()
        {
            IWebDriver navegador = new ChromeDriver();

            navegador.Url = "http://localhost:58972/Auth/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#user"));
            input1Busqueda.SendKeys("admin");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#pass"));
            input2Busqueda.SendKeys("admin");

            var boton = navegador.FindElement(By.CssSelector("#ingresar"));
            boton.Click();
            var buscarId = navegador.FindElement(By.CssSelector("#EstoyEnIndexHome"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
        [Test]
        public void VerificarQueAgregoSuLibroBibliotecaIngresoLogin()
        {
            IWebDriver navegador = new ChromeDriver();

            navegador.Url = "http://localhost:58972/Auth/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#user"));
            input1Busqueda.SendKeys("admin");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#pass"));
            input2Busqueda.SendKeys("admin");

            var boton = navegador.FindElement(By.CssSelector("#ingresar"));
            boton.Click();
            navegador.Url = "http://localhost:58972/biblioteca/add?libro=5";
            var buscarId = navegador.FindElement(By.CssSelector("#agregado"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
        [Test]
        public void VerificarQueIngresoABiblioteca()
        {
            IWebDriver navegador = new ChromeDriver();

            navegador.Url = "http://localhost:58972/Auth/Login";

            var input1Busqueda = navegador.FindElement(By.CssSelector("#user"));
            input1Busqueda.SendKeys("admin");
            var input2Busqueda = navegador.FindElement(By.CssSelector("#pass"));
            input2Busqueda.SendKeys("admin");

            var boton = navegador.FindElement(By.CssSelector("#ingresar"));
            boton.Click();
            navegador.Url = "http://localhost:58972/Biblioteca";
            var buscarId = navegador.FindElement(By.CssSelector("#EstoyEnBiblioteca"));

            Assert.IsNotNull(buscarId);
            navegador.Close();
        }
    }
}
