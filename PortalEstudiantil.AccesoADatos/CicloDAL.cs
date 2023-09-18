using Microsoft.EntityFrameworkCore;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.AccesoADatos
{
    public class CicloDAL
    {
        public static async Task<int> CrearAsync(Ciclo pCiclo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pCiclo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> ModificarAsync(Ciclo pCiclo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var ciclo = await bdContexto.Ciclo.FirstOrDefaultAsync(s => s.Id == pCiclo.Id);
                ciclo.Nombre = pCiclo.Nombre;
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<int> EliminarAsync(Ciclo pCiclo)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var ciclo = await bdContexto.Ciclo.FirstOrDefaultAsync(s => s.Id == pCiclo.Id);
                bdContexto.Ciclo.Remove(ciclo);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }

        public static async Task<Ciclo> ObtenerPorIdAsync(Ciclo pCiclo)
        {
            var ciclo = new Ciclo();
            using (var bdContexto = new BDContexto())
            {
                ciclo = await bdContexto.Ciclo.FirstOrDefaultAsync(s => s.Id == pCiclo.Id);
            }
            return ciclo;
        }

        public static async Task<List<Ciclo>> ObtenerTodosAsync()
        {
            var ciclos = new List<Ciclo>();
            using (var bdContexto = new BDContexto())
            {
                ciclos = await bdContexto.Ciclo.ToListAsync();
            }
            return ciclos;
        }

        internal static IQueryable<Ciclo> QuerySelect(IQueryable<Ciclo> pQuery, Ciclo pCiclo)
        {
            if (pCiclo.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pCiclo.Id);
            if (!string.IsNullOrWhiteSpace(pCiclo.Nombre))
                pQuery = pQuery.Where(s => s.Nombre == pCiclo.Nombre);
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pCiclo.Top_Aux > 0)
                pQuery = pQuery.Take(pCiclo.Top_Aux).AsQueryable();

            return pQuery;
        }

        public static async Task<List<Ciclo>> BuscarAsync(Ciclo pCiclo)
        {
            var ciclos = new List<Ciclo>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Ciclo.AsQueryable();
                select = QuerySelect(select, pCiclo);
                ciclos = await select.ToListAsync();
            }
            return ciclos;
        }
    }
}
