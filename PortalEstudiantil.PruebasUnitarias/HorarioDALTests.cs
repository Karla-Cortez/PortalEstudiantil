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
    public class HorarioDALTests
    {
        private static Horario horarioInicial = new Horario { Id = 7, GradoId = 1, MateriaId = 1, DocenteId = 1 };

        [TestMethod()]
        public async Task T1CrearAsyncTest()
        {
            var horario = new Horario();
            horario.GradoId = horarioInicial.GradoId;
            horario.MateriaId = horarioInicial.MateriaId;
            horario.DocenteId = horarioInicial.DocenteId;
            horario.Dia = "Lunes";
            horario.HorarioInicio = "7:30 AM";
            horario.HorarioSalida = "11:25 AM";
            int result = await HorarioDAL.CrearAsync(horario);
            Assert.AreNotEqual(0, result);
            horarioInicial.Id = horario.Id;
        }

        [TestMethod()]
        public async Task T2ModificarAsyncTest()
        {
            var horario = new Horario();
            horario.Id = horarioInicial.Id;
            horario.GradoId = horarioInicial.GradoId;
            horario.MateriaId = horarioInicial.MateriaId;
            horario.DocenteId = horarioInicial.DocenteId;
            horario.Dia = "Miercoles";
            horario.HorarioInicio = "7:35 AM";
            horario.HorarioSalida = "11:30 AM";
            int result = await HorarioDAL.ModificarAsync(horario);
            Assert.AreNotEqual(2, result);
        }

        [TestMethod()]
        public async Task T3ObtenerPorIdAsyncTest()
        {
            var horario = new Horario();
            horario.Id = horarioInicial.Id;
            var resultMunicipio = await HorarioDAL.ObtenerPorIdAsync(horario);
            Assert.AreEqual(horario.Id, resultMunicipio.Id);
        }


        [TestMethod()]
        public async Task T4ObtenerTodosAsyncTest()
        {
            var resultHorarios = await HorarioDAL.ObtenerTodosAsync();
            Assert.AreNotEqual(0, resultHorarios.Count);
        }

        [TestMethod()]
        public async Task T5BuscarAsyncTest()
        {
            var horario = new Horario();
            horario.GradoId = horarioInicial.GradoId;
            horario.MateriaId = horarioInicial.MateriaId;
            horario.DocenteId = horarioInicial.DocenteId;
            horario.Dia = "Lunes";
            horario.HorarioInicio = "am";
            horario.HorarioSalida = "mm";
            horario.Top_Aux = 10;
            var resultHorarios = await HorarioDAL.BuscarAsync(horario);
            Assert.AreNotEqual(0, resultHorarios.Count);
        }

        
        [TestMethod()]
        public async Task T6BuscarIncluirGradoAsyncTest()
        {
            var horario = new Horario();
            horario.GradoId = horarioInicial.GradoId;

            horario.Dia = "Lunes";
            horario.HorarioInicio = "am";
            horario.HorarioSalida = "mm";
            horario.Top_Aux = 10;
            var resultHorario = await HorarioDAL.BuscarIncluirGradoAsync(horario);
            Assert.AreNotEqual(0, resultHorario.Count);
            var ultimoHorario = resultHorario.FirstOrDefault();
            Assert.IsTrue( ultimoHorario.Grado != null && horario.GradoId == ultimoHorario.Grado.Id);

        }

        [TestMethod()]
        public async Task T6BuscarIncluirMateriaAsyncTest()
        {
            var horario = new Horario();
            horario.MateriaId = horarioInicial.MateriaId;
            horario.Dia = "Lunes";
            horario.HorarioInicio = "am";
            horario.HorarioSalida = "mm";
            horario.Top_Aux = 10;
            var resultHorario = await HorarioDAL.BuscarIncluirMateriaAsync(horario);
            Assert.AreNotEqual(0, resultHorario.Count);
            var ultimoHorario = resultHorario.FirstOrDefault();
            Assert.IsTrue(ultimoHorario.Materia != null && horario.MateriaId == ultimoHorario.Materia.Id);
        }

        [TestMethod()]
        public async Task T6BuscarIncluirDocenteAsyncTest()
        {
            var horario = new Horario();
            horario.DocenteId = horarioInicial.DocenteId;
            horario.Dia = "Lunes";
            horario.HorarioInicio = "am";
            horario.HorarioSalida = "mm";
            horario.Top_Aux = 10;
            var resultHorario = await HorarioDAL.BuscarIncluirDocenteAsync(horario);
            Assert.AreNotEqual(0, resultHorario.Count);
            var ultimoHorario = resultHorario.FirstOrDefault();
            Assert.IsTrue(ultimoHorario.Docente != null && horario.DocenteId == ultimoHorario.Docente.Id);
        }

        [TestMethod()]
        public async Task T7EliminarAsyncTest()
        {
            var horario = new Horario();
            horario.Id = horarioInicial.Id;
            int result = await HorarioDAL.EliminarAsync(horario);
            Assert.AreNotEqual(0, result);
        }
    }
}