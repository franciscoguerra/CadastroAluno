using CadastroAluno.Models;
using CadastroAluno.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;



namespace CadastroAluno.Controller
{
    [Route("api/[controller]")]
    [ApiController]

    public class CursosController : ControllerBase
    {
        private readonly IServiceCurso _serviceCursos;
        private readonly ILogger _logger;
        public CursosController(IServiceCurso serviceCurso, ILogger<CursosController> logger)
        {
            _serviceCursos = serviceCurso;
            _logger = logger;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IAsyncEnumerable<CursoModel>>> GetCursos()
        {
            try
            {
                var cursos = await _serviceCursos.GetCursos();
                return Ok(cursos);
            }
            catch (Exception ex)
            {
                
                _logger.LogError(ex, "Erro ao obter Cursos");
                //return BadRequest("Request Invalido");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter Cursos");


            }
        }

        [HttpGet("curso/{id}")]
        public async Task<ActionResult<CursoModel>> GetById(int id)
        {
            try
            {
                var curso = await _serviceCursos.GetCursoId(id);
                if (curso == null)
                {
                    return NotFound($"Não há Curso para esse id={id}");
                }
                return Ok(curso);
            }
            catch (Exception)
            {
                return BadRequest("Bad Request invalido!");
                
            }
        }

        [HttpPost]
        public async Task<ActionResult<CursoModel>> Create(CursoModel cursoModel)
        {
            try
            {
                await _serviceCursos.CreateCurso(cursoModel);
                return CreatedAtRoute(nameof(GetCursos), new {id = cursoModel.Id},cursoModel);
            }
            catch (Exception)
            {

               return BadRequest("Requeste Inalido!");
            }
        }

        [HttpPut]
        public async Task<ActionResult<CursoModel>> Edit(int id, [FromBody]CursoModel cursoModel)
        {
            try
            {
                if(cursoModel.Id ==id)
                {
                    await _serviceCursos.UpdateCurso(cursoModel);
                    return Ok($"Curso com o Id={id} foi atualizado!");
                }
                else
                {

                    return BadRequest(" Dados inconsistentes");
                }
            }
            catch (Exception)
            {

                return BadRequest("Request Invalido!");
            }
        }

        [HttpDelete("Curos/{Id}")]
        public async Task<ActionResult<CursoModel>> Delite(int id)
        {
            try
            {
                var curso = await _serviceCursos.GetCursoId(id);
                if(curso != null)
                {
                    await _serviceCursos.DeleteCurso(curso);
                    return Ok($"Curso com Id={id} deletado");
                }
                else
                {
                   return NotFound("Curso não encontrado!");
                }

            }
            catch (Exception)
            {

                return BadRequest("Bad Request invalido");
            }
        }
     
    }
}
