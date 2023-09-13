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
    public class TurnoDALTests
    {
        private static Turno turnoInicial = new Turno { Id = 4 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var turno = new Turno();
            turno.Nombre = "Mañana";
            int result = await TurnoDAL.CrearAsync(turno);
            Assert.AreNotEqual(0, result);
            turnoInicial.Id = turno.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var turno = new Turno();
            turno.Id = turnoInicial.Id;
            turno.Nombre = "Tarde";
            int result = await TurnoDAL.ModificarAsync(turno);
            Assert.AreNotEqual(0, result);

        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var turno = new Turno();
            turno.Id = turnoInicial.Id;
            var resultTurno = await TurnoDAL.ObtenerPorIdAsync(turno);
            Assert.AreEqual(turno.Id, resultTurno.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultTurnos = await TurnoDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultTurnos.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var turno = new Turno();
            turno.Nombre = "a";
            turno.Top_Aux = 10;
            var resultTurnos = await TurnoDAL.BuscarAsync(turno);
            Assert.AreNotEqual(1, resultTurnos.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var turno = new Turno();
            turno.Id = turnoInicial.Id;
            int result = await TurnoDAL.EliminarAsync(turno);
            Assert.AreNotEqual(0, result);
        }
    }
}