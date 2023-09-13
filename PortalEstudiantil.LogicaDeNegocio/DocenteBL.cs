using PortalEstudiantil.AccesoADatos;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.LogicaDeNegocio
{
    public class DocenteBL
    {
        public async Task<int> CrearAsync(Docente pDocente)
        {
            return await DocenteDAL.CrearAsync(pDocente);
        }

        public async Task<int> ModificarAsync(Docente pDocente)
        {
            return await DocenteDAL.ModificarAsync(pDocente);
        }

        public async Task<int> EliminarAsync(Docente pDocente)
        {
            return await DocenteDAL.EliminarAsync(pDocente);
        }   

        public async Task<Docente> ObtenerPorIdAsync(Docente pDocente)
        {
            return await DocenteDAL.ObtenerPorIdAsync(pDocente);
        }

        public async Task<List<Docente>> ObtenerTodosAsync()
        {
            return await DocenteDAL.ObtenerTodosAsync();
        }

        public async Task<List<Docente>> BuscarAsync(Docente pDocente)
        {
            return await DocenteDAL.BuscarAsync(pDocente);
        }

        public async Task<Docente> LoginAsync(Docente pDocente)
        {
            return await DocenteDAL.LoginAsync(pDocente);
        }

        public async Task<int> CambiarPasswordAsync(Docente pDocente, string pPasswordAnt)
        {
            return await DocenteDAL.CambiarPasswordAsync(pDocente, pPasswordAnt);
        }

        public async Task<List<Docente>> BuscarIncluirRolAsync(Docente pDocente)
        {
            return await DocenteDAL.BuscarIncluirRolAsync(pDocente);
        }
        public async Task<List<Docente>> BuscarIncluirMateriaAsync(Docente pDocente)
        {
            return await DocenteDAL.BuscarIncluirMateriaAsync(pDocente);
        }
        public async Task<List<Docente>> BuscarIncluirCicloAsync(Docente pDocente)
        {
            return await DocenteDAL.BuscarIncluirCicloAsync(pDocente);
        }
        public async Task<List<Docente>> BuscarIncluirTurnoAsync(Docente pDocente)
        {
            return await DocenteDAL.BuscarIncluirTurnoAsync(pDocente);
        }
    }
}
