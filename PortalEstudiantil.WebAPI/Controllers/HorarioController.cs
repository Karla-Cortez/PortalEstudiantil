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
    public class HorarioController : ControllerBase
    {
        private HorarioBL horarioBL = new HorarioBL();

        // Codigo para agregar la seguridad JWT
        private readonly IJwtAuthenticationServices authService;
        public HorarioController(IJwtAuthenticationServices pAuthService)
        {
            authService = pAuthService;
        }

        [HttpGet]
        public async Task<IEnumerable<Horario>> Get()
        {
            return await horarioBL.ObtenerTodosAsync();
        }

        [HttpGet("{id}")]
        public async Task<Horario> Get(short id)
        {
            Horario horario = new Horario();
            horario.Id = id;
            return await horarioBL.ObtenerPorIdAsync(horario);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Horario horario)
        {
            try
            {
                await horarioBL.CrearAsync(horario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pHorario)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strHorario = JsonSerializer.Serialize(pHorario);
            Horario horario = JsonSerializer.Deserialize<Horario>(strHorario, option);
            if (horario.Id == id)
            {
                await horarioBL.ModificarAsync(horario);
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
                Horario horario = new Horario();
                horario.Id = id;
                await horarioBL.EliminarAsync(horario);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        //Preguntar  y como agregar las demas lllaves foraneas

        [HttpPost("Buscar")]
        public async Task<List<Horario>> BuscarDocente([FromBody] object pHorario)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strHorario = JsonSerializer.Serialize(pHorario);
            Horario horario = JsonSerializer.Deserialize<Horario>(strHorario, option);
            var horarios = await horarioBL.BuscarIncluirDocenteAsync(horario);
            horarios.ForEach(s => s.Docente.horario = null); // Evitar la redundacia de datos
            return horarios;
           
            
        }
        public async Task<List<Horario>> BuscarMateria([FromBody] object pHorario)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strHorario = JsonSerializer.Serialize(pHorario);
            Horario horario = JsonSerializer.Deserialize<Horario>(strHorario, option);
            var horarios = await horarioBL.BuscarIncluirMateriaAsync(horario);
            horarios.ForEach(s => s.Materia.horario = null); // Evitar la redundacia de datos
            return horarios;
            //grado
            //materia

        }
        public async Task<List<Horario>> BuscarGrado([FromBody] object pHorario)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strHorario = JsonSerializer.Serialize(pHorario);
            Horario horario = JsonSerializer.Deserialize<Horario>(strHorario, option);
            var horarios = await horarioBL.BuscarIncluirGradoAsync(horario);
            horarios.ForEach(s => s.Grado.horario = null); // Evitar la redundacia de datos
            return horarios;
            

        }

    }
}
