using PortalEstudiantil.AccesoADatos;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.LogicaDeNegocio
{
    public class EstudianteBL
    {
        public async Task<int> CrearAsync(Estudiante pEstudiante)
        {
            return await EstudianteDAL.CrearAsync(pEstudiante);
        }

        public async Task<int> ModificarAsync(Estudiante pEstudiante)
        {
            return await EstudianteDAL.ModificarAsync(pEstudiante);
        }

        public async Task<int> EliminarAsync(Estudiante pEstudiante)
        {
            return await EstudianteDAL.EliminarAsync(pEstudiante);
        }

        public async Task<Estudiante> ObtenerPorIdAsync(Estudiante pEstudiante)
        {
            return await EstudianteDAL.ObtenerPorIdAsync(pEstudiante);
        }

        public async Task<List<Estudiante>> ObtenerTodosAsync()
        {
            return await EstudianteDAL.ObtenerTodosAsync();
        }

        public async Task<List<Estudiante>> BuscarAsync(Estudiante pEstudiante)
        {
            return await EstudianteDAL.BuscarAsync(pEstudiante);
        }

        public async Task<List<Estudiante>> BuscarIncluirGradoAsync(Estudiante pEstudiante)
        {
            return await EstudianteDAL.BuscarIncluirGradoAsync(pEstudiante);
        }
        public async Task<List<Estudiante>> BuscarIncluirTurnoAsync(Estudiante pEstudiante)
        {
            return await EstudianteDAL.BuscarIncluirTurnoAsync(pEstudiante);
        }
    }
}
