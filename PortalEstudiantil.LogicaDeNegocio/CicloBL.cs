using PortalEstudiantil.AccesoADatos;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.LogicaDeNegocio
{
    public class CicloBL
    {
        public async Task<int> CrearAsync(Ciclo pCiclo)
        {
            return await CicloDAL.CrearAsync(pCiclo);
        }

        public async Task<int> ModificarAsync(Ciclo pCiclo)
        {
            return await CicloDAL.ModificarAsync(pCiclo);
        }

        public async Task<int> EliminarAsync(Ciclo pCiclo)
        {
            return await CicloDAL.EliminarAsync(pCiclo);
        }

        public async Task<Ciclo> ObtenerPorIdAsync(Ciclo pCiclo)
        {
            return await CicloDAL.ObtenerPorIdAsync(pCiclo);
        }

        public async Task<List<Ciclo>> ObtenerTodosAsync()
        {
            return await CicloDAL.ObtenerTodosAsync();
        }

        public async Task<List<Ciclo>> BuscarAsync(Ciclo pCiclo)
        {
            return await CicloDAL.BuscarAsync(pCiclo);
        }
    }
}
