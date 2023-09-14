using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalEstudiantil.EntidadesDeNegocio;
using PortalEstudiantil.LogicaDeNegocio;
using PortalEstudiantil.WebAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;

namespace PortalEstudiantil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private TurnoBL turnoBL = new TurnoBL();

        // Codigo para agregar la seguridad JWT
        private readonly IJwtAuthenticationServices authService;
        public TurnoController(IJwtAuthenticationServices pAuthService)
        {
            authService = pAuthService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Turno turno)
        {
            try
            {
                await turnoBL.CrearAsync(turno);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pTurno)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strTurno = JsonSerializer.Serialize(pTurno);
            Turno turno = JsonSerializer.Deserialize<Turno>(strTurno, option);
            if (turno.Id == id)
            {
                await turnoBL.ModificarAsync(turno);
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
                Turno turno = new Turno();
                turno.Id = id;
                await turnoBL.EliminarAsync(turno);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<Turno> Get(short id)
        {
            Turno turno = new Turno();
            turno.Id = id;
            return await turnoBL.ObtenerPorIdAsync(turno);
        }

        [HttpGet]
        public async Task<IEnumerable<Turno>> Get()
        {
            return await turnoBL.ObtenerTodosAsync();
        }

        [HttpPost("Buscar")]
        public async Task<List<Turno>> Buscar([FromBody] object pTurno)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strTurno = JsonSerializer.Serialize(pTurno);
            Turno turno = JsonSerializer.Deserialize<Turno>(strTurno, option);
            return await turnoBL.BuscarAsync(turno);
        }
    }
}
