using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalEstudiantil.EntidadesDeNegocio;
using PortalEstudiantil.LogicaDeNegocio;
using System.Text.Json;

namespace PortalEstudiantil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GradoController : ControllerBase
    {
        private GradoBL gradoBL = new GradoBL();

        [HttpGet]
        public async Task<IEnumerable<Grado>> Get()
        {
            return await gradoBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Grado> Get(short id)
        {
            Grado grado = new Grado();
            grado.Id = id;
            return await gradoBL.ObtenerPorIdAsync(grado);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Grado grado)
        {
            try
            {
                await gradoBL.CrearAsync(grado);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Grado grado)
        {
            if (grado.Id == id)
            {
                await gradoBL.ModificarAsync(grado);
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
                Grado grado = new Grado();
                grado.Id = id;
                await gradoBL.EliminarAsync(grado);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        [HttpPost("Buscar")]
        public async Task<List<Grado>> Buscar([FromBody] object pGrado)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strGrado = JsonSerializer.Serialize(pGrado);
            Grado grado = JsonSerializer.Deserialize<Grado>(strGrado, option);
            return await gradoBL.BuscarAsync(grado);
        }

    }

}
