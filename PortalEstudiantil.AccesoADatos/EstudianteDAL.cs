using Microsoft.EntityFrameworkCore;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.AccesoADatos
{
    public class EstudianteDAL
    {
        public static async Task<int> CrearAsync(Estudiante pEstudiante)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pEstudiante);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Estudiante pEstudiante)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var estudiante = await bdContexto.Estudiante.FirstOrDefaultAsync(s => s.Id == pEstudiante.Id);
                estudiante.Nombre = pEstudiante.Nombre;
                estudiante.Apellido = pEstudiante.Apellido;
                estudiante.CodigoEstudiante = pEstudiante.CodigoEstudiante;
                estudiante.GradoId = pEstudiante.GradoId;
                estudiante.TurnoId = pEstudiante.TurnoId;
                estudiante.Encargado = pEstudiante.Encargado;
                estudiante.EncargadoDUI = pEstudiante.EncargadoDUI;
                estudiante.Correo = pEstudiante.Correo;
                estudiante.Direccion = pEstudiante.Direccion;
                estudiante.Telefono = pEstudiante.Telefono;
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Estudiante pEstudiante)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var estudiante = await bdContexto.Estudiante.FirstOrDefaultAsync(s => s.Id == pEstudiante.Id);
                bdContexto.Estudiante.Remove(estudiante);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Estudiante> ObtenerPorIdAsync(Estudiante pEstudiante)
        {
            var estudiante = new Estudiante();
            using (var bdContexto = new BDContexto())
            {
                estudiante = await bdContexto.Estudiante.FirstOrDefaultAsync(s => s.Id == pEstudiante.Id);
            }
            return estudiante;
        }

        public static async Task<List<Estudiante>> ObtenerTodosAsync()
        {
            var estudiantes = new List<Estudiante>();
            using (var bdContexto = new BDContexto())
            {
                estudiantes = await bdContexto.Estudiante.ToListAsync();
            }
            return estudiantes;
        }

        internal static IQueryable<Estudiante> QuerySelect(IQueryable<Estudiante> pQuery, Estudiante pEstudiante)
        {
            if (pEstudiante.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pEstudiante.Id);

            if (!string.IsNullOrWhiteSpace(pEstudiante.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pEstudiante.Nombre));

            if (!string.IsNullOrWhiteSpace(pEstudiante.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pEstudiante.Apellido));

            if (!string.IsNullOrWhiteSpace(pEstudiante.CodigoEstudiante))
                pQuery = pQuery.Where(s => s.CodigoEstudiante.Contains(pEstudiante.CodigoEstudiante));

            if (pEstudiante.GradoId > 0)
                pQuery = pQuery.Where(s => s.GradoId == pEstudiante.GradoId);

            if (pEstudiante.TurnoId > 0)
                pQuery = pQuery.Where(s => s.TurnoId == pEstudiante.TurnoId);

            if (!string.IsNullOrWhiteSpace(pEstudiante.Encargado))
                pQuery = pQuery.Where(s => s.Encargado.Contains(pEstudiante.Encargado));

            if (pEstudiante.EncargadoDUI > 0)
                pQuery = pQuery.Where(s => s.Id == pEstudiante.EncargadoDUI);

            if (!string.IsNullOrWhiteSpace(pEstudiante.Correo))
                pQuery = pQuery.Where(s => s.Correo.Contains(pEstudiante.Correo));

            if (!string.IsNullOrWhiteSpace(pEstudiante.Direccion))
                pQuery = pQuery.Where(s => s.Direccion.Contains(pEstudiante.Direccion));

            if (pEstudiante.Telefono > 0)
                pQuery = pQuery.Where(s => s.Id == pEstudiante.Telefono);

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pEstudiante.Top_Aux > 0)
                pQuery = pQuery.Take(pEstudiante.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Estudiante>> BuscarAsync(Estudiante pEstudiante)
        {
            var estudiantes = new List<Estudiante>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Estudiante.AsQueryable();
                select = QuerySelect(select, pEstudiante);
                estudiantes = await select.ToListAsync();
            }
            return estudiantes;
        }

        public static async Task<List<Estudiante>> BuscarIncluirGradoAsync(Estudiante pEstudiante)
        {
            var estudiantes = new List<Estudiante>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Estudiante.AsQueryable();
                select = QuerySelect(select, pEstudiante).Include(s => s.Grado).AsQueryable();
                estudiantes = await select.ToListAsync();
            }
            return estudiantes;
        }

        public static async Task<List<Estudiante>> BuscarIncluirTurnoAsync(Estudiante pEstudiante)
        {
            var estudiantes = new List<Estudiante>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Estudiante.AsQueryable();
                select = QuerySelect(select, pEstudiante).Include(s => s.Turno).AsQueryable();
                estudiantes = await select.ToListAsync();
            }
            return estudiantes;
        }
    }
}

