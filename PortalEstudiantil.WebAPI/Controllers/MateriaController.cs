using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalEstudiantil.AccesoADatos;
using PortalEstudiantil.EntidadesDeNegocio;
using PortalEstudiantil.LogicaDeNegocio;
using PortalEstudiantil.WebAPI.Auth;
using System.Text.Json;

namespace PortalEstudiantil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MateriaController : ControllerBase
    {
        private MateriaBL materiaBL = new MateriaBL();

        // Codigo para agregar la seguridad JWT
        private readonly IJwtAuthenticationServices authService;
        public MateriaController(IJwtAuthenticationServices pAuthService)
        {
            authService = pAuthService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Materia materia)
        {
            try
            {
                await materiaBL.CrearAsync(materia);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pMateria)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strMateria = JsonSerializer.Serialize(pMateria);
            Materia materia = JsonSerializer.Deserialize<Materia>(strMateria, option);
            if (materia.Id == id)
            {
                await materiaBL.ModificarAsync(materia);
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
                Materia materia = new Materia();
                materia.Id = id;
                await materiaBL.EliminarAsync(materia);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<Materia> Get(short id)
        {
            Materia materia = new Materia();
            materia.Id = id;
            return await materiaBL.ObtenerPorIdAsync(materia);
        }

        [HttpGet]
        public async Task<IEnumerable<Materia>> Get()
        {
            return await materiaBL.ObtenerTodosAsync();
        }

        [HttpPost("Buscar")]
        public async Task<List<Materia>> Buscar([FromBody] object pMateria)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strMateria = JsonSerializer.Serialize(pMateria);
            Materia materia = JsonSerializer.Deserialize<Materia>(strMateria, option);
            return await materiaBL.BuscarAsync(materia);
        }
    }
}
