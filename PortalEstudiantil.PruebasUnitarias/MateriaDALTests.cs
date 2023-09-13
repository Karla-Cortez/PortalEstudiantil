using Microsoft.VisualStudio.TestTools.UnitTesting;
using PortalEstudiantil.AccesoADatos;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.AccesoADatos.Tests
{
    [TestClass()]
    public class MateriaDALTests
    {
        private static Materia materiaInicial = new Materia { Id = 1};

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var materia = new Materia();
            materia.Nombre = "Sociales";
            int result = await MateriaDAL.CrearAsync(materia);
            Assert.AreNotEqual(0, result);
            materiaInicial.Id = materia.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var materia = new Materia();
            materia.Id = materiaInicial.Id;
            materia.Nombre = "Tarde";
            int result = await MateriaDAL.ModificarAsync(materia);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var materia = new Materia();
            materia.Id = materiaInicial.Id;
            var resultMateria = await MateriaDAL.ObtenerPorIdAsync(materia);
            Assert.AreEqual(materia.Id , resultMateria.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultMaterias = await MateriaDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultMaterias.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var materia = new Materia();
            materia.Nombre = "a";
            materia.Top_Aux = 10;
            var resultMaterias = await MateriaDAL.BuscarAsync(materia);
            Assert.AreNotEqual(1, resultMaterias.Count);
        }

        [TestMethod()]
        public async Task T6EliminarAsyncTest()
        {
            var materia = new Materia();
            materia.Id = materiaInicial.Id;
            int result = await MateriaDAL.EliminarAsync(materia);
            Assert.AreNotEqual(0, result);
        }
    }
}