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
    public class EstudianteDALTests
    {
        private static Estudiante estudianteInicial = new Estudiante { Id = 3, GradoId = 1, TurnoId = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var estudiante = new Estudiante();

            estudiante.Nombre = "Raúl";
            estudiante.Apellido = "Cortez";
            estudiante.CodigoEstudiante = "RC001";
            estudiante.GradoId = estudianteInicial.GradoId;
            estudiante.TurnoId = estudianteInicial.TurnoId;
            estudiante.Encargado = "Gerardo";
            estudiante.EncargadoDUI = 1234587;
            estudiante.Correo = "RC@gmail.com";
            estudiante.Direccion = "Sonsonate";
            estudiante.Telefono =60602525;
            int result = await EstudianteDAL.CrearAsync(estudiante);
            Assert.AreNotEqual(0, result);
            estudianteInicial.Id = estudiante.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var estudiante = new Estudiante();
            estudiante.Nombre = "Juan";
            estudiante.Apellido = "Cortez";
            estudiante.CodigoEstudiante = "RC001";
            estudiante.GradoId = estudianteInicial.GradoId;
            estudiante.TurnoId = estudianteInicial.TurnoId;
            estudiante.Encargado = "Gerardo";
            estudiante.EncargadoDUI = 1234587;
            estudiante.Correo = "RC@gmail.com";
            estudiante.Direccion = "Sonsonate";
            estudiante.Telefono = 60602;
            int result = await EstudianteDAL.ModificarAsync(estudiante);
            Assert.AreNotEqual(0, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var estudiante = new Estudiante();
            estudiante.Id = estudianteInicial.GradoId;
            estudiante.Nombre = "Raúl";
            estudiante.Apellido = "Cortez";
            estudiante.CodigoEstudiante = "RC001";
            estudiante.GradoId = estudianteInicial.GradoId;
            estudiante.TurnoId = estudianteInicial.TurnoId;
            estudiante.Encargado = "Gerardo";
            estudiante.EncargadoDUI = estudianteInicial.EncargadoDUI;
            estudiante.Correo = "RC@gmail.com";
            estudiante.Direccion = "Sonsonate";
            estudiante.Telefono = estudianteInicial.Telefono;
            var resultEstudiante = await EstudianteDAL.ObtenerPorIdAsync(estudiante);
            Assert.AreNotEqual(0, resultEstudiante.Id);
        }

        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var estudiante = new Estudiante();
            estudiante.Id = estudianteInicial.GradoId;
            estudiante.Nombre = "Raúl";
            estudiante.Apellido = "Cortez";
            estudiante.CodigoEstudiante = "RC001";
            estudiante.GradoId = estudianteInicial.GradoId;
            estudiante.TurnoId = estudianteInicial.TurnoId;
            estudiante.Encargado = "Gerardo";
            estudiante.EncargadoDUI = estudianteInicial.EncargadoDUI;
            estudiante.Correo = "RC@gmail.com";
            estudiante.Direccion = "Sonsonate";
            estudiante.Telefono = estudianteInicial.Telefono;
            var resultEstudiante = await EstudianteDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultEstudiante.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var estudiante = new Estudiante();
            estudiante.Nombre = "Raúl";
            estudiante.Apellido = "Cortez";
            estudiante.CodigoEstudiante = "RC001";
            estudiante.GradoId = estudianteInicial.GradoId;
            estudiante.TurnoId = estudianteInicial.TurnoId;
            estudiante.Encargado = "Gerardo";
            estudiante.EncargadoDUI = 1234587;
            estudiante.Correo = "RC@gmail.com";
            estudiante.Direccion = "Sonsonate";
            estudiante.Telefono = 60602525;
            estudiante.Top_Aux = 10;
            var resultEstudiante = await EstudianteDAL.BuscarAsync(estudiante);
            Assert.AreNotEqual(0, resultEstudiante.Count);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirGradoAsyncTest()
        {
            var estudiante = new Estudiante();
            estudiante.Id = estudianteInicial.GradoId;

            estudiante.Nombre = "Raúl";
            estudiante.Apellido = "Cortez";
            estudiante.CodigoEstudiante = "RC001";
            estudiante.GradoId = estudianteInicial.GradoId;
            estudiante.TurnoId = estudianteInicial.TurnoId;
            estudiante.Encargado = "Gerardo";
            estudiante.EncargadoDUI = estudianteInicial.EncargadoDUI;
            estudiante.Correo = "RC@gmail.com";
            estudiante.Direccion = "Sonsonate";
            estudiante.Telefono = estudianteInicial.Telefono;
            estudiante.Top_Aux = 10;
            var resultEstudiante = await EstudianteDAL.BuscarIncluirGradoAsync(estudiante);
            Assert.AreNotEqual(0, resultEstudiante.Count);
            var ultimoEstudiante = resultEstudiante.FirstOrDefault();
            Assert.IsTrue(ultimoEstudiante.Grado != null && estudiante.GradoId == ultimoEstudiante.Grado.Id);
        }

        [TestMethod()]
        public async Task T7BuscarIncluirTurnoAsyncTest()
        {
            var estudiante = new Estudiante();
            estudiante.Id = estudianteInicial.GradoId;
            estudiante.Nombre = "Raúl";
            estudiante.Apellido = "Cortez";
            estudiante.CodigoEstudiante = "RC001";
            estudiante.GradoId = estudianteInicial.GradoId;
            estudiante.TurnoId = estudianteInicial.TurnoId;
            estudiante.Encargado = "Gerardo";
            estudiante.EncargadoDUI = estudianteInicial.EncargadoDUI;
            estudiante.Correo = "RC@gmail.com";
            estudiante.Direccion = "Sonsonate";
            estudiante.Telefono = estudianteInicial.Telefono;
            estudiante.Top_Aux = 10;
            var resultEstudiante = await EstudianteDAL.BuscarIncluirTurnoAsync(estudiante);
            Assert.AreNotEqual(0, resultEstudiante);
            var ultimoEstudiante = resultEstudiante.FirstOrDefault();
            Assert.IsTrue(ultimoEstudiante.Turno != null && estudiante.TurnoId == ultimoEstudiante.Turno.Id);
        }

        [TestMethod()]
        public async Task T8EliminarAsyncTest()
        {
            var estudiante = new Estudiante();
            estudiante.Id = estudianteInicial.GradoId;
            estudiante.Nombre = "Raúl";
            estudiante.Apellido = "Cortez";
            estudiante.CodigoEstudiante = "RC001";
            estudiante.GradoId = estudianteInicial.GradoId;
            estudiante.TurnoId = estudianteInicial.TurnoId;
            estudiante.Encargado = "Gerardo";
            estudiante.EncargadoDUI = estudianteInicial.EncargadoDUI;
            estudiante.Correo = "RC@gmail.com";
            estudiante.Direccion = "Sonsonate";
            estudiante.Telefono = estudianteInicial.Telefono;
            int result = await EstudianteDAL.EliminarAsync(estudiante);
            Assert.AreNotEqual(0, result);
        }
    }
}