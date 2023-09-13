using PortalEstudiantil.AccesoADatos;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.LogicaDeNegocio
{
    public class MateriaBL
    {
        public async Task<int> CrearAsync(Materia pMateria)
        {
            return await MateriaDAL.CrearAsync(pMateria);
        }

        public async Task<int> ModificarAsync(Materia pMateria)
        {
            return await MateriaDAL.ModificarAsync(pMateria);
        }

        public async Task<int> EliminarAsync(Materia pMateria)
        {
            return await MateriaDAL.EliminarAsync(pMateria);
        }

        public async Task<Materia> ObtenerPorIdAsync(Materia pMateria)
        {
            return await MateriaDAL.ObtenerPorIdAsync(pMateria);
        }

        public async Task<List<Materia>> ObtenerTodosAsync()
        {
            return await MateriaDAL.ObtenerTodosAsync();
        }

        public async Task<List<Materia>> BuscarAsync(Materia pMateria)
        {
            return await MateriaDAL.BuscarAsync(pMateria);
        }
    }
}
