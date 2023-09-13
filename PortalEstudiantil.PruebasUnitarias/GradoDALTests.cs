using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortalEstudiantil.AccesoADatos;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.AccesoADatos.Tests
{
    [TestClass()]
    public class GradoDALTests
    {
        private static Grado gradoInicial = new Grado { Id = 3 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var grado = new Grado();
            grado.Nombre = "Noveno";
            int result = await GradoDAL.CrearAsync(grado);
            Assert.AreNotEqual(0, result);
            gradoInicial.Id = grado.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var grado = new Grado();
            grado.Id = gradoInicial.Id;
            grado.Nombre = "Noveno";
            int result = await GradoDAL.ModificarAsync(grado);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var grado = new Grado();
            grado.Id = gradoInicial.Id;
            var resultRol = await GradoDAL.ObtenerPorIdAsync(grado);
            Assert.AreEqual(grado.Id, resultRol.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultCiclo = await RolDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultCiclo.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var grado = new Grado();
            grado.Nombre = "1° A";
            grado.Top_Aux = 10;
            var resultGrado = await GradoDAL.BuscarAsync(grado);
            Assert.AreNotEqual(0, resultGrado.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var grado = new Grado();
            grado.Id = gradoInicial.Id;
            int result = await GradoDAL.EliminarAsync(grado);
            Assert.AreNotEqual(0, result);
        }
    }
}