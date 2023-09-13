using Microsoft.EntityFrameworkCore;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.AccesoADatos
{
    public class HorarioDAL
    {
        public static async Task<int> CrearAsync(Horario pHorario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pHorario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Horario pHorario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var horario = await bdContexto.Horario.FirstOrDefaultAsync(s => s.Id == pHorario.Id);
                horario.GradoId = pHorario.GradoId;
                horario.MateriaId = pHorario.MateriaId;
                horario.DocenteId = pHorario.DocenteId;
                horario.Dia = pHorario.Dia;
                horario.HorarioInicio = pHorario.HorarioInicio;
                horario.HorarioSalida = pHorario.HorarioSalida;
                bdContexto.Horario.Remove(horario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Horario pHorario)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var horario = await bdContexto.Horario.FirstOrDefaultAsync(s => s.Id == pHorario.Id);
                bdContexto.Horario.Remove(horario);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Horario> ObtenerPorIdAsync(Horario pHorario)
        {
            var horario = new Horario();
            using (var bdContexto = new BDContexto())
            {
                horario = await bdContexto.Horario.FirstOrDefaultAsync(s => s.Id == pHorario.Id);
            }
            return horario;
        }
        public static async Task<List<Horario>> ObtenerTodosAsync()
        {
            var horarios = new List<Horario>();
            using (var bdContexto = new BDContexto())
            {
                horarios = await bdContexto.Horario.ToListAsync();
            }
            return horarios;
        }
        internal static IQueryable<Horario> QuerySelect(IQueryable<Horario> pQuery, Horario pHorario)
        {
            if (pHorario.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pHorario.Id);

            if(pHorario.GradoId > 0)
                pQuery = pQuery.Where(s => s.GradoId == pHorario.GradoId);

            if(pHorario.MateriaId > 0)
                pQuery = pQuery.Where(s => s.MateriaId == pHorario.MateriaId);

            if(pHorario.DocenteId > 0)
                pQuery = pQuery.Where(s => s.DocenteId == pHorario.DocenteId);

            if (!string.IsNullOrWhiteSpace(pHorario.Dia))
                pQuery = pQuery.Where(s => s.Dia.Contains(pHorario.Dia));

            if (!string.IsNullOrWhiteSpace(pHorario.HorarioInicio))
                pQuery = pQuery.Where(s => s.HorarioInicio.Contains(pHorario.HorarioInicio));

            if (!string.IsNullOrWhiteSpace(pHorario.HorarioSalida))
                pQuery = pQuery.Where(s => s.HorarioSalida.Contains(pHorario.HorarioSalida));

            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pHorario.Top_Aux > 0)
                pQuery = pQuery.Take(pHorario.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Horario>> BuscarAsync(Horario pHorario)
        {
            var horarios = new List<Horario>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Horario.AsQueryable();
                select = QuerySelect(select, pHorario);
                horarios = await select.ToListAsync();
            }
            return horarios;
        }

        public static async Task<List<Horario>> BuscarIncluirGradoAsync(Horario pHorario)
        {
            var horarios = new List<Horario>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Horario.AsQueryable();
                select = QuerySelect(select, pHorario).Include(s => s.Grado).AsQueryable();
                horarios = await select.ToListAsync();
            }
            return horarios;
        }

        public static async Task<List<Horario>> BuscarIncluirMateriaAsync(Horario pHorario)
        {
            var horarios = new List<Horario>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Horario.AsQueryable();
                select = QuerySelect(select, pHorario).Include(s => s.Materia).AsQueryable();
                horarios = await select.ToListAsync();
            }
            return horarios;
        }
        public static async Task<List<Horario>> BuscarIncluirDocenteAsync(Horario pHorario)
        {
            var horarios = new List<Horario>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Horario.AsQueryable();
                select = QuerySelect(select, pHorario).Include(s => s.Docente).AsQueryable();
                horarios = await select.ToListAsync();
            }
            return horarios;
        }
    }
}
