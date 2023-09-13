using Microsoft.EntityFrameworkCore;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.AccesoADatos
{
    public class TurnoDAL
    {
        public static async Task<int> CrearAsync(Turno pTurno)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                bdContexto.Add(pTurno);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync(Turno pTurno)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var turno = await bdContexto.Turno.FirstOrDefaultAsync(s => s.Id == pTurno.Id);
                turno.Nombre = pTurno.Nombre;
                bdContexto.Turno.Remove(turno);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync(Turno pTurno)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var turno = await bdContexto.Turno.FirstOrDefaultAsync(s => s.Id == pTurno.Id);
                bdContexto.Turno.Remove(turno);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<Turno> ObtenerPorIdAsync(Turno pTurno)
        {
            var turno = new Turno();
            using (var bdContexto = new BDContexto())
            {
                turno = await bdContexto.Turno.FirstOrDefaultAsync(s => s.Id == pTurno.Id);
            }
            return turno;
        }

        public static async Task<List<Turno>> ObtenerTodosAsync( )
        {
            var turnos = new List<Turno>();
            using (var bdContexto = new BDContexto())
            {
                turnos = await bdContexto.Turno.ToListAsync();
            }
            return turnos;
        }
        internal static IQueryable<Turno> QuerySelect(IQueryable<Turno> pQuery, Turno pTurno)
        {
            if (pTurno.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pTurno.Id);
            if (!string.IsNullOrWhiteSpace(pTurno.Nombre))
                pQuery = pQuery.Where(s => s.Nombre == pTurno.Nombre);
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();
            if (pTurno.Top_Aux > 0)
                pQuery = pQuery.Take(pTurno.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Turno>> BuscarAsync(Turno pTurno)
        {
            var turnos = new List<Turno>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Turno.AsQueryable();
                select = QuerySelect(select, pTurno);
                turnos = await select.ToListAsync();
            }
            return turnos;
        }
    }
}

