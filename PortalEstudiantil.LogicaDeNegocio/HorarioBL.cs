using PortalEstudiantil.AccesoADatos;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.LogicaDeNegocio
{
    public class HorarioBL
    {
        public async Task<int> CrearAsync(Horario pHorario)
        {
            return await HorarioDAL.CrearAsync(pHorario);
        }

        public async Task<int> ModificarAsync(Horario pHorario)
        {
            return await HorarioDAL.ModificarAsync(pHorario);
        }

        public async Task<int> EliminarAsync(Horario pHorario)
        {
            return await HorarioDAL.EliminarAsync(pHorario);
        }

        public async Task<Horario> ObtenerPorIdAsync(Horario pHorario)
        {
            return await HorarioDAL.ObtenerPorIdAsync(pHorario);
        }

        public async Task<List<Horario>> ObtenerTodosAsync()
        {
            return await HorarioDAL.ObtenerTodosAsync();
        }

        public async Task<List<Horario>> BuscarAsync(Horario pHorario)
        {
            return await HorarioDAL.BuscarAsync(pHorario);
        }

        public async Task<List<Horario>> BuscarIncluirGradoAsync(Horario pHorario)
        {
            return await HorarioDAL.BuscarIncluirGradoAsync(pHorario);
        }
        public async Task<List<Horario>> BuscarIncluirMateriaAsync(Horario pHorario)
        {
            return await HorarioDAL.BuscarIncluirMateriaAsync(pHorario);
        }
        public async Task<List<Horario>> BuscarIncluirDocenteAsync(Horario pHorario)
        {
            return await HorarioDAL.BuscarIncluirDocenteAsync(pHorario);
        }

    }
}
