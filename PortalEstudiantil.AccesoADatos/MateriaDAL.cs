using Microsoft.EntityFrameworkCore;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.AccesoADatos
{
    public class MateriaDAL
    {
        public static async Task<int> CrearAsync(Materia pMateria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pMateria);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Materia pMateria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var materia = await bdContexto.Materia.FirstOrDefaultAsync(m => m.Id == pMateria.Id);
                materia.Nombre = pMateria.Nombre;
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Materia pMateria)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var materia = await bdContexto.Materia.FirstOrDefaultAsync(s => s.Id == pMateria.Id);
                bdContexto.Materia.Remove(materia);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Materia> ObtenerPorIdAsync(Materia pMateria)
        {
            var materia = new Materia();
            using (var bdContexto = new BDContexto())
            {
                materia = await bdContexto.Materia.FirstOrDefaultAsync(s => s.Id == pMateria.Id);
            }
            return materia;
        }

        public static async Task<List<Materia>> ObtenerTodosAsync( )
        {
            var materias = new List<Materia>();
            using (var bdContexto = new BDContexto())
            {
                materias = await bdContexto.Materia.ToListAsync();
            }
            return materias;
        }
        internal static IQueryable<Materia> QuerySelect(IQueryable<Materia> pQuery, Materia pMateria)
        {
            if (pMateria.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pMateria.Id);
            if (!string.IsNullOrWhiteSpace(pMateria.Nombre))
                pQuery = pQuery.Where(s => s.Nombre == pMateria.Nombre);
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pMateria.Top_Aux > 0)
                pQuery = pQuery.Take(pMateria.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Materia>> BuscarAsync(Materia pMateria)
        {
            var materias = new List<Materia>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Materia.AsQueryable();
                select = QuerySelect(select, pMateria);
                materias = await select.ToListAsync();
            }
            return materias;
        }
    }
}
