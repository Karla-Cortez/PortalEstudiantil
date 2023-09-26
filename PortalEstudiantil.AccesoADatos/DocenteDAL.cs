using Microsoft.EntityFrameworkCore;
using PortalEstudiantil.EntidadesDeNegocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PortalEstudiantil.AccesoADatos
{
    public class DocenteDAL
    {
        private static void EncriptarMD5 (Docente pDocente)
        {
            using (var md5 = MD5.Create())
            {
                var result = md5.ComputeHash(Encoding.ASCII.GetBytes(pDocente.Clave));
                var strEncriptar = "";
                for (int i = 0; i < result.Length; i++)
                    strEncriptar += result[i].ToString("x2").ToLower();
                pDocente.Clave = strEncriptar;
            }
        }
        private static async Task<bool> ExisteLogin(Docente pDocente, BDContexto pDbContext)
        {
            bool result = false;
            var loginDocenteExiste = await pDbContext.Docente.FirstOrDefaultAsync(s => s.CodigoDocente == pDocente.CodigoDocente && s.Id != pDocente.Id);
            if (loginDocenteExiste != null && loginDocenteExiste.Id > 0 && loginDocenteExiste.CodigoDocente == pDocente.CodigoDocente)
                result = true;
            return result;
        }
        public static async Task<int> CrearAsync (Docente pDocente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                EncriptarMD5(pDocente);
                bdContexto.Add(pDocente);         
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> ModificarAsync (Docente pDocente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var docente = await bdContexto.Docente.FirstOrDefaultAsync(s => s.Id == pDocente.Id);
                docente.Nombre = pDocente.Nombre;
                docente.Apellido = pDocente.Apellido;
                docente.CodigoDocente = pDocente.CodigoDocente;
                docente.Clave = pDocente.Clave;
                docente.RolId = pDocente.RolId;
                docente.MateriaId = pDocente.MateriaId;
                docente.CicloId = pDocente.CicloId;
                docente.TurnoId = pDocente.TurnoId;
                docente.DUI = pDocente.DUI;
                docente.Correo = pDocente.Correo;
                docente.Dirección = pDocente.Dirección;
                docente.Telefono = pDocente.Telefono;
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task<int> EliminarAsync (Docente pDocente)
        {
            int result = 0;
            using (var bdContexto = new BDContexto())
            {
                var docente = await bdContexto.Docente.FirstOrDefaultAsync(s => s.Id == pDocente.Id);
                bdContexto.Docente.Remove(docente);
                result = await bdContexto.SaveChangesAsync();
            }
            return result;
        }
        public static async Task <Docente> ObtenerPorIdAsync(Docente pDocente)
        {
            var docente = new Docente();
            using (var bdContexto = new BDContexto())
            {
                docente = await bdContexto.Docente.FirstOrDefaultAsync(s => s.Id == pDocente.Id);
            }
            return docente;

        }
        public static async Task<List<Docente>> ObtenerTodosAsync()
        {
            var docentes = new List<Docente>();
            using (var bdContexto = new BDContexto())
            {
                docentes = await bdContexto.Docente.ToListAsync();
            }
            return docentes;
        }
        internal static IQueryable<Docente> QuerySelect(IQueryable<Docente> pQuery, Docente pDocente)
        {
            if (pDocente.Id > 0)
                pQuery = pQuery.Where(s => s.Id == pDocente.Id);
            if (!string.IsNullOrWhiteSpace(pDocente.Nombre))
                pQuery = pQuery.Where(s => s.Nombre.Contains(pDocente.Nombre));

            if (!string.IsNullOrWhiteSpace(pDocente.Apellido))
                pQuery = pQuery.Where(s => s.Apellido.Contains(pDocente.Apellido));

            if (!string.IsNullOrWhiteSpace(pDocente.CodigoDocente))
                pQuery = pQuery.Where(s => s.CodigoDocente.Contains(pDocente.CodigoDocente));

            if (pDocente.RolId > 0)
                pQuery = pQuery.Where(s => s.RolId == pDocente.RolId);

            if (pDocente.MateriaId > 0)
                pQuery = pQuery.Where(s => s.MateriaId == pDocente.MateriaId);

            if (pDocente.CicloId > 0)
                pQuery = pQuery.Where(s => s.CicloId == pDocente.CicloId);

            if (pDocente.TurnoId > 0)
                pQuery = pQuery.Where(s => s.TurnoId == pDocente.TurnoId);

            if (pDocente.DUI > 0)
                pQuery = pQuery.Where(s => s.DUI == pDocente.DUI);

            if (!string.IsNullOrWhiteSpace(pDocente.Correo))
                pQuery = pQuery.Where(s => s.Correo.Contains(pDocente.Correo));

            if (!string.IsNullOrWhiteSpace(pDocente.Dirección))
                pQuery = pQuery.Where(s => s.Dirección.Contains(pDocente.Dirección));

            if (pDocente.Telefono > 0)
                pQuery = pQuery.Where(s => s.Id == pDocente.Telefono);
            pQuery = pQuery.OrderByDescending(s => s.Id).AsQueryable();

            if (pDocente.Top_Aux > 0)
                pQuery = pQuery.Take(pDocente.Top_Aux).AsQueryable();

            return pQuery;
        }
        public static async Task<List<Docente>> BuscarAsync(Docente pDocente)
        {
            var docentes = new List<Docente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Docente.AsQueryable();
                select = QuerySelect(select, pDocente);
                docentes = await select.ToListAsync();
            }
            return docentes;
        }

        public static async Task<List<Docente>> BuscarIncluirReferenciasAsync(Docente pDocente)
        {
            var docentes = new List<Docente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Docente.AsQueryable();
                select = QuerySelect(select, pDocente).Include(s => s.Rol).Include(s => s.Materia).Include(s => s.Ciclo).Include(s => s.Turno).AsQueryable();
                docentes = await select.ToListAsync();
            }
            return docentes;
        }

        public static async Task<List<Docente>> BuscarIncluirRolAsync(Docente pDocente)
        {
            var docentes = new List<Docente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Docente.AsQueryable();
                select = QuerySelect(select, pDocente).Include(s => s.Rol).AsQueryable();
                docentes = await select.ToListAsync();
            }
            return docentes;
        }
        public static async Task<List<Docente>> BuscarIncluirMateriaAsync(Docente pDocente)
        {
            var docentes = new List<Docente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Docente.AsQueryable();
                select = QuerySelect(select, pDocente).Include(s => s.Materia).AsQueryable();
                docentes = await select.ToListAsync();
            }
            return docentes;
        }
        public static async Task<List<Docente>> BuscarIncluirCicloAsync(Docente pDocente)
        {
            var docentes = new List<Docente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Docente.AsQueryable();
                select = QuerySelect(select, pDocente).Include(s => s.Ciclo).AsQueryable();
                docentes = await select.ToListAsync();
            }
            return docentes;
        }
        public static async Task<List<Docente>> BuscarIncluirTurnoAsync(Docente pDocente)
        {
            var docentes = new List<Docente>();
            using (var bdContexto = new BDContexto())
            {
                var select = bdContexto.Docente.AsQueryable();
                select = QuerySelect(select, pDocente).Include(s => s.Turno).AsQueryable();
                docentes = await select.ToListAsync();
            }
            return docentes;
        }
        public static async Task<Docente> LoginAsync(Docente pDocente)
        {
            var docente = new Docente();
            using (var bdContexto = new BDContexto())
            {
                EncriptarMD5(pDocente);
                docente = await bdContexto.Docente.FirstOrDefaultAsync(s => s.CodigoDocente == pDocente.CodigoDocente &&
                s.Clave == pDocente.Clave);
            }
            return docente;
        }
        public static async Task<int> CambiarPasswordAsync(Docente pDocente, string pPasswordAnt)
        {
            int result = 0;
            var docentePassAnt = new Docente { Clave = pPasswordAnt };
            EncriptarMD5(docentePassAnt);
            using (var bdContexto = new BDContexto())
            {
                var docente = await bdContexto.Docente.FirstOrDefaultAsync(s => s.Id == pDocente.Id);
                if (docentePassAnt.Clave == docente.Clave)
                {
                    EncriptarMD5(pDocente);
                    docente.Clave = pDocente.Clave;
                    bdContexto.Update(docente);
                    result = await bdContexto.SaveChangesAsync();
                }
                else
                    throw new Exception("El password actual es incorrecto");
            }
            return result;
        }
    }


}