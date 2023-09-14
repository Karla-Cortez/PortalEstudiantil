using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PortalEstudiantil.WebAPI.Auth;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using PortalEstudiantil.EntidadesDeNegocio;
using PortalEstudiantil.LogicaDeNegocio;
using PortalEstudiantil.AccesoADatos;

namespace PortalEstudiantil.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstudianteController : ControllerBase
    {
        private EstudianteBL estudianteBL = new EstudianteBL();

        // Codigo para agregar la seguridad JWT
        private readonly IJwtAuthenticationServices authService;
        public EstudianteController(IJwtAuthenticationServices pAuthService)
        {
            authService = pAuthService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Estudiante estudiante)
        {
            try
            {
                await estudianteBL.CrearAsync(estudiante);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] object pEstudiante)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strEstudiante = JsonSerializer.Serialize(pEstudiante);
            Estudiante estudiante = JsonSerializer.Deserialize<Estudiante>(strEstudiante, option);
            if (estudiante.Id == id)
            {
                await estudianteBL.ModificarAsync(estudiante);
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
                Estudiante estudiante = new Estudiante();
                estudiante.Id = id;
                await estudianteBL.EliminarAsync(estudiante);
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public async Task<Estudiante> Get(short id)
        {
            Estudiante estudiante = new Estudiante();
            estudiante.Id = id;
            return await estudianteBL.ObtenerPorIdAsync(estudiante);
        }

        [HttpGet]
        public async Task<IEnumerable<Estudiante>> Get()
        {
            return await estudianteBL.ObtenerTodosAsync();
        }

        [HttpPost("Buscar")]
        public async Task<List<Estudiante>> Buscar([FromBody] object pEstudiante)
        {
            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strEstudiante = JsonSerializer.Serialize(pEstudiante);
            Estudiante estudiante = JsonSerializer.Deserialize<Estudiante>(strEstudiante, option);
            return await estudianteBL.BuscarAsync(estudiante);
        }

        [HttpPost("Buscar")]
        public async Task<List<Estudiante>> BuscarGrado([FromBody] object pEstudiante)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strEstudiante = JsonSerializer.Serialize(pEstudiante);
            Estudiante estudiante = JsonSerializer.Deserialize<Estudiante>(strEstudiante, option);
            var estudiantes = await estudianteBL.BuscarIncluirGradoAsync(estudiante);
            estudiantes.ForEach(s => s.Grado.estudiante = null); // Evitar la redundacia de datos
            return estudiantes;
        }


        [HttpPost("Buscar")]
        public async Task<List<Estudiante>> BuscarTurno([FromBody] object pEstudiante)
        {

            var option = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            string strEstudiante = JsonSerializer.Serialize(pEstudiante);
            Estudiante estudiante = JsonSerializer.Deserialize<Estudiante>(strEstudiante, option);
            var estudiantes = await estudianteBL.BuscarIncluirTurnoAsync(estudiante);
            estudiantes.ForEach(s => s.Turno.Estudiante = null); // Evitar la redundacia de datos
            return estudiantes;
        }
    }
}
