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
    public class DocenteDALTests
    {
        private static Docente docenteInicial = new Docente { Id = 3, RolId = 1, MateriaId = 1, CicloId = 1, TurnoId = 1, CodigoDocente = "ar22001", Clave = "guau" };
        [TestMethod()]
        public async Task T01CrearAsyncTest()
        {
            var docente = new Docente();
            docente.RolId = docenteInicial.RolId;
            docente.MateriaId = docenteInicial.MateriaId;
            docente.CicloId = docenteInicial.CicloId;
            docente.TurnoId = docenteInicial.TurnoId;
            docente.Nombre = "Jose";
            docente.Apellido = "Avalos";
            docente.CodigoDocente = "ja12";
            docente.Clave = "1234";
            docente.DUI = docenteInicial.DUI;
            docente.Correo = "ja12@gmail.com";
            docente.Dirección = "Sonsonate";
            docente.Telefono = docenteInicial.Telefono;
            var result = await DocenteDAL.CrearAsync(docente);
            Assert.AreEqual(1, result);
            docenteInicial.Id = docente.Id = docenteInicial.CicloId = docente.CicloId;
        }

        [TestMethod()]
        public async Task T02ModificarAsyncTest()
        {
            var docente = new Docente();
            docente.Id = docenteInicial.Id ;
            docente.RolId = docenteInicial.RolId;
            docente.MateriaId = docenteInicial.MateriaId;
            docente.CicloId = docenteInicial.CicloId;
            docente.TurnoId = docenteInicial.TurnoId;
            docente.Nombre = "Alexander";
            docente.Apellido = "Valdez";
            docente.CodigoDocente = "ja122";
            docente.Clave = "1234";
            docente.DUI = docenteInicial.DUI;
            docente.Correo = "ja12@gmail.com";
            docente.Dirección = "Sonsonate";
            docente.Telefono = docenteInicial.Telefono;
            int result = await DocenteDAL.ModificarAsync(docente);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T03ObtenerPorIdAsyncTest()
        {
            var docente = new Docente();
            docente.Id = docenteInicial.Id;
            var resultDocente = await DocenteDAL.ObtenerPorIdAsync(docente);
            Assert.AreEqual(docente.Id, resultDocente.Id);
        }

        [TestMethod()]
        public async Task T04ObtenerTodosAsyncTest()
        {
            var resultDocentes = await DocenteDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultDocentes.Count);
        }

        [TestMethod()]
        public async Task T05BuscarAsyncTest()
        {
            var docente = new Docente();
            docente.RolId = docenteInicial.RolId;
            docente.MateriaId = docenteInicial.MateriaId;
            docente.CicloId = docenteInicial.CicloId;
            docente.TurnoId = docenteInicial.TurnoId;
            docente.Nombre = "A";
            docente.Apellido = "a";
            docente.Top_Aux = 10;
            var resultDocentes = await DocenteDAL.BuscarAsync(docente);
            Assert.AreNotEqual(0, resultDocentes.Count);
        }

        [TestMethod()]
        public async Task T06BuscarIncluirRolAsyncTest()
        {
            var docente = new Docente();
            docente.RolId = docenteInicial.RolId;
            docente.Nombre = "A";
            docente.Apellido = "a";
            docente.Top_Aux = 10;
            var resultDocentes = await DocenteDAL.BuscarIncluirRolAsync(docente);
            var ultimoDocente = resultDocentes.FirstOrDefault();
            Assert.IsTrue(ultimoDocente.Rol != null && docente.RolId == ultimoDocente.Rol.Id);

        }

        [TestMethod()]
        public async Task T07BuscarIncluirMateriaAsyncTest()
        {
            var docente = new Docente();
            docente.MateriaId = docenteInicial.MateriaId;
            docente.Nombre = "A";
            docente.Apellido = "a";
            docente.Top_Aux = 10;
            var resultDocentes = await DocenteDAL.BuscarIncluirMateriaAsync(docente);
            var ultimoDocente = resultDocentes.FirstOrDefault();
            Assert.IsTrue(ultimoDocente.Materia != null && docente.MateriaId == ultimoDocente.Materia.Id);

        }

        [TestMethod()]
        public async Task T08BuscarIncluirCicloAsyncTest()
        {
            var docente = new Docente();
            docente.CicloId = docenteInicial.CicloId;
            docente.Nombre = "A";
            docente.Apellido = "a";
            docente.Top_Aux = 10;
            var resultDocentes = await DocenteDAL.BuscarIncluirCicloAsync(docente);
            var ultimoDocente = resultDocentes.FirstOrDefault();
            Assert.IsTrue(ultimoDocente.Ciclo != null && docente.CicloId == ultimoDocente.Ciclo.Id);

        }

        [TestMethod()]
        public async Task T09BuscarIncluirTurnoAsyncTest()
        {
            var docente = new Docente();
            docente.TurnoId = docenteInicial.TurnoId;
            docente.Nombre = "A";
            docente.Apellido = "a";
            docente.Top_Aux = 10;
            var resultDocentes = await DocenteDAL.BuscarIncluirTurnoAsync(docente);
            var ultimoDocente = resultDocentes.FirstOrDefault();
            Assert.IsTrue(ultimoDocente.Turno != null && docente.TurnoId == ultimoDocente.Turno.Id);

        }

        [TestMethod()]
        public async Task T10LoginAsyncTest()
        {
            var docente = new Docente();
            docente.CodigoDocente = docenteInicial.CodigoDocente;
            docente.Clave = docenteInicial.Clave;
            var resultDocente = await DocenteDAL.LoginAsync(docente);
            Assert.AreEqual(docente.CodigoDocente, resultDocente.CodigoDocente);
        }

        [TestMethod()]
        public async Task T11CambiarPasswordAsyncTest()
        {
            var docente = new Docente();
            docente.Id = docenteInicial.Id;
            string passwordNuevo = "123456";
            docente.Clave = passwordNuevo;
            var result = await DocenteDAL.CambiarPasswordAsync(docente, docenteInicial.Clave);
            Assert.AreNotEqual(0, result);
            docenteInicial.Clave = passwordNuevo;
        }
        [TestMethod()]
        public async Task T12EliminarAsyncTest()
        {
            var docente = new Docente();
            docente.Id = docenteInicial.Id;
            int result = await DocenteDAL.EliminarAsync(docente);
            Assert.AreNotEqual(0, result);
        }

    }
}