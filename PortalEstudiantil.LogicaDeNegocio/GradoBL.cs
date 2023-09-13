using PortalEstudiantil.AccesoADatos;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.LogicaDeNegocio
{
    public class GradoBL
    {
        public async Task<int> CrearAsync(Grado pGrado)
        {
            return await GradoDAL.CrearAsync(pGrado);
        }

        public async Task<int> ModificarAsync(Grado pGrado)
        {
            return await GradoDAL.ModificarAsync(pGrado);
        }

        public async Task<int> EliminarAsync(Grado pGrado)
        {
            return await GradoDAL.EliminarAsync(pGrado);
        }

        public async Task<Grado> ObtenerPorIdAsync(Grado pGrado)
        {
            return await GradoDAL.ObtenerPorIdAsync(pGrado);
        }

        public async Task<List<Grado>> ObtenerTodosAsync()
        {
            return await GradoDAL.ObtenerTodosAsync();
        }

        public async Task<List<Grado>> BuscarAsync(Grado pGrado)
        {
            return await GradoDAL.BuscarAsync(pGrado);
        }
    }
}
