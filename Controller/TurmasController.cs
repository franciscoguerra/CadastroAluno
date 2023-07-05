using CadastroAluno.Models;
using CadastroAluno.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAluno.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        private IGeneric _servicesTurma;
        public TurmasController(IGeneric servicesTurma)
        {
            _servicesTurma = servicesTurma;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IAsyncEnumerable<TurmaModel>>> GetTurmas() 
        {
            try
            {
                var turma = await _servicesTurma.GetGenericAll<TurmaModel>();
                return Ok(turma);
            }
            catch
            {
                //return BadRequest("Request Invalido");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter Turma");


            }
        }

        [HttpGet("turma/{id}")]
        public async Task<ActionResult<TurmaModel>> GetById(int id)
        {
            try
            {
                var turma = await _servicesTurma.GetGenericById<TurmaModel>(id);
                if (turma == null)
                {
                    return NotFound($"Não há Turma para esse id={id}");
                }
                return Ok(turma);
            }
            catch (Exception)
            {
                return BadRequest("Bad Request invalido!");

            }
        }

        [HttpPost]
        public async Task<ActionResult<TurmaModel>> Create(TurmaModel turmaModel)
        {
            try
            {
                await _servicesTurma.Create(turmaModel);
                return CreatedAtRoute(nameof(GetTurmas), new { id = turmaModel.Id }, turmaModel);
            }
            catch (Exception)
            {

               return BadRequest("Request invalido!");
            }
        }

        [HttpPut("Turmas/{id}")]
        public async Task<ActionResult<TurmaModel>> Edit(int id, [FromBody] TurmaModel turmaModel)
        {
            try
            {
                if(turmaModel.Id == id)
                {
                    await _servicesTurma.Update(turmaModel);
                    return Ok($"Turma com ID={id} Atualizado!");
                }
                else
                {
                    return BadRequest("Dados inconsistentes!");
                }
                


            }
            catch (Exception)
            {

                return BadRequest("Request invalido!");
            }
        }

        [HttpDelete("int:id")]
        public async Task<ActionResult<TurmaModel>> Delite(int id)
        {
            try
            {
                var turma = await _servicesTurma.GetGenericById<TurmaModel>(id);
                if(turma != null)
                {
                    await _servicesTurma.Delete(turma);
                    return Ok($"Turma deletada com sucesso Id={id}");
                }
                else
                {
                    return NotFound("Turma não encontrada!");
                }
            }
            catch (Exception)
            {

                return BadRequest("Request invalido!");
            }
        }


    }
}
