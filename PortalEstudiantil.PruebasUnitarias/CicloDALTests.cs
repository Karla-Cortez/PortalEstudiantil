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
    public class CicloDALTests
    {
        private static Ciclo cicloInicial = new Ciclo { Id = 3 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var ciclo = new Ciclo();
            ciclo.Nombre = "Uno";
            int result = await CicloDAL.CrearAsync(ciclo);
            Assert.AreNotEqual(0, result);
            cicloInicial.Id = ciclo.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var ciclo = new Ciclo();
            ciclo.Id = cicloInicial.Id;
            ciclo.Nombre = "Uno";
            int result = await CicloDAL.ModificarAsync(ciclo);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var ciclo = new Ciclo();
            ciclo.Id = cicloInicial.Id;
            var resultCiclo = await CicloDAL.ObtenerPorIdAsync(ciclo);
            Assert.AreEqual(ciclo.Id, resultCiclo.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultCiclo = await CicloDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultCiclo.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var ciclo = new Ciclo();
            ciclo.Nombre = "Tercer Ciclo";
            ciclo.Top_Aux = 10;
            var resultCiclo = await CicloDAL.BuscarAsync(ciclo);
            Assert.AreNotEqual(0, resultCiclo.Count);
        }
        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var ciclo = new Ciclo();
            ciclo.Id = cicloInicial.Id;
            int result = await CicloDAL.EliminarAsync(ciclo);
            Assert.AreNotEqual(0, result);
        }
    }
}