using PortalEstudiantil.AccesoADatos;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.LogicaDeNegocio
{
    public class TurnoBL
    {
        public async Task<int> CrearAsync(Turno pTurno)
        {
            return await TurnoDAL.CrearAsync(pTurno);
        }

        public async Task<int> ModificarAsync(Turno pTurno)
        {
            return await TurnoDAL.ModificarAsync(pTurno);
        }

        public async Task<int> EliminarAsync(Turno pTurno)
        {
            return await TurnoDAL.EliminarAsync(pTurno);
        }

        public async Task<Turno> ObtenerPorIdAsync(Turno pTurno)
        {
            return await TurnoDAL.ObtenerPorIdAsync(pTurno);
        }

        public async Task<List<Turno>> ObtenerTodosAsync()
        {
            return await TurnoDAL.ObtenerTodosAsync();
        }

        public async Task<List<Turno>> BuscarAsync(Turno pTurno)
        {
            return await TurnoDAL.BuscarAsync(pTurno);
        }
    }
}
