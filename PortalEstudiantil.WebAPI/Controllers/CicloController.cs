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
    public class CicloController : ControllerBase
    {
        private CicloBL cicloBL = new CicloBL();

        // Codigo para agregar la seguridad JWT
        private readonly IJwtAuthenticationServices authService;
        public CicloController(IJwtAuthenticationServices pAuthService)
        {
            authService = pAuthService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Ciclo ciclo)
        {
            try
            {
                await cicloBL.CrearAsync(ciclo);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pCiclo)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCiclo = JsonSerializer.Serialize(pCiclo);
            Ciclo ciclo = JsonSerializer.Deserialize<Ciclo>(strCiclo, option);
            if (ciclo.Id == id)
            {
                await cicloBL.ModificarAsync(ciclo);
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
                Ciclo ciclo = new Ciclo();
                ciclo.Id = id;
                await cicloBL.EliminarAsync(ciclo);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<Ciclo> Get(short id)
        {
            Ciclo ciclo = new Ciclo();
            ciclo.Id = id;
            return await cicloBL.ObtenerPorIdAsync(ciclo);
        }

        [HttpGet]
        public async Task<IEnumerable<Ciclo>> Get()
        {
            return await cicloBL.ObtenerTodosAsync();
        }

        [HttpPost("Buscar")]
        public async Task<List<Ciclo>> Buscar([FromBody] object pCiclo)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strCiclo = JsonSerializer.Serialize(pCiclo);
            Ciclo ciclo = JsonSerializer.Deserialize<Ciclo>(strCiclo, option);
            return await cicloBL.BuscarAsync(ciclo);
        }
    }
}
