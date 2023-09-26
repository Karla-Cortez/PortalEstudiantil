using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalEstudiantil.LogicaDeNegocio;
using PortalEstudiantil.WebAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using PortalEstudiantil.EntidadesDeNegocio;

namespace PortalEstudiantil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class DocenteController : ControllerBase
    {
        private DocenteBL docenteBL = new DocenteBL();

        // Codigo para agregar la seguridad JWT
        private readonly IJwtAuthenticationServices authService;
        public DocenteController(IJwtAuthenticationServices pAuthService)
        {
            authService = pAuthService;
        }

        [HttpGet]
        public async Task<IEnumerable<Docente>> Get()
        {
            return await docenteBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Docente> Get(short id)
        {
            Docente docente = new Docente();
            docente.Id = id;
            return await docenteBL.ObtenerPorIdAsync(docente);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Docente docente)
        {
            try
            {
                await docenteBL.CrearAsync(docente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pDocente)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDocente = JsonSerializer.Serialize(pDocente);
            Docente docente = JsonSerializer.Deserialize<Docente>(strDocente, option);
            if (docente.Id == id)
            {
                await docenteBL.ModificarAsync(docente);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(short id)
        {
            try
            {
                Docente docente = new Docente();
                docente.Id = id;
                await docenteBL.EliminarAsync(docente);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost("Buscar")]
        public async Task<List<Docente>> Buscar([FromBody] object pDocente)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDocente = JsonSerializer.Serialize(pDocente);
            Docente docente = JsonSerializer.Deserialize<Docente>(strDocente, option);
            var docentes = await docenteBL.BuscarIncluirReferenciasAsync(docente);
            docentes.ForEach(s => s.Ciclo.docente = null);// Evitar la redundacia de datos
            docentes.ForEach(s => s.Materia.docente = null);
            docentes.ForEach(s => s.Turno.docente = null);
            docentes.ForEach(s => s.Rol.Docente = null);
            return docentes;
        }

        [HttpPost("Login")]
        [AllowAnonymous]
        public async Task<ActionResult> Login([FromBody] object pDocente)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strDocente = JsonSerializer.Serialize(pDocente);
            Docente docente = JsonSerializer.Deserialize<Docente>(strDocente, option);
            // codigo para autorizar el usuario por JWT
            Docente docente_auth = await docenteBL.LoginAsync(docente);
            if (docente_auth != null && docente_auth.Id > 0 && docente.CodigoDocente == docente_auth.CodigoDocente)
            {
                var token = authService.Authenticate(docente_auth);
                return Ok(token);
            }
            else
            {
                return Unauthorized();
            }
        }

        [HttpPost("CambiarPassword")]
        public async Task<ActionResult> CambiarPassword([FromBody] Object pDocente)
        {
            try
            {
                var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                string strDocente = JsonSerializer.Serialize(pDocente);
                Docente docente = JsonSerializer.Deserialize<Docente>(strDocente, option);
                await docenteBL.CambiarPasswordAsync(docente, docente.ConfirmPassword_aux);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
