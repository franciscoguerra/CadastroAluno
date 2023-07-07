using CadastroAluno.Models;
using CadastroAluno.Services;
using CadastroAluno.Services.IServices;
using CadastroAluno.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CadastroAluno.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        private readonly IServicesAluno _servicesAluno;
        private readonly IGeneric _servicesTurma;
        public AlunosController(IServicesAluno servicesAluno, IGeneric serviceTurma)
        {
            _servicesAluno = servicesAluno;
            _servicesTurma = serviceTurma;
        }

        
     
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<IAsyncEnumerable<AlunoModel>>> GetAlunos()
        {
            try
            {
                var alunos = await _servicesAluno.GetAlunos();
                return Ok(alunos);
            }
            catch
            {
                //return BadRequest("Request Invalido");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Erro ao obter alunos");


            }
        }


        [HttpGet("Aluno-Name")]
        public async Task<ActionResult<IAsyncEnumerable<AlunoModel>>>
            GetAlunosByName([FromQuery] string nome)
        {
           try
             {
                    var alunos = await _servicesAluno.GetAlunosByNome(nome);
                    

                    if (alunos == null)
                        return NotFound($"Não existem alunos com o criterio {nome}");
                    return Ok(alunos);
                }
                catch
                {
                    //return BadRequest("Request Invalido");
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        "Erro ao obter alunos");


                }
        }

        [HttpGet("Aluno/{id}")]
        public  async Task<ActionResult<AlunoModel>> GetAlunoById(int id)
        {
            try
            {
                var aluno = await _servicesAluno.GetAlunoId(id);

                if (aluno == null)
                    return NotFound($"Não existe aluno com o id = {id}");
                return Ok(aluno);   
            }
            catch (Exception)
            {

                return BadRequest("Request Invalido");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create(AlunoViewModel alunoViewModel)
        {
            var alunoModel = new AlunoModel
            {
                FirstNome = alunoViewModel.FirstNome,
                LastName = alunoViewModel.LastName,
                CertidaoNascimento = alunoViewModel.CertidaoNascimento,
                CPF= alunoViewModel.CPF,
                NomeMae = alunoViewModel.NomeMae,
                NomePai = alunoViewModel.NomePai,
                Status = alunoViewModel.Status,
            };
            try
            {
                
                await _servicesAluno.CreateAluno(alunoModel);
                return Ok(alunoModel);
                //return CreatedAtRoute(nameof(GetAlunos), new {id = alunoModel.Id}, alunoModel);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Edit(int id, [FromBody] AlunoModel alunoModel)
        {
            try
            {
                if(alunoModel.Id==id)
                {
                    await _servicesAluno.UpdateAluno(alunoModel);
                    return Ok($"Aluno com id={id} foi atualizado com sucesso");
                }
                else
                {
                    return BadRequest("Dados inconsistentes");
                }
            }
            catch (Exception)
            {

                return BadRequest("Request Ivalido");
            }

        }

        [HttpDelete("id:int")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var aluno = await _servicesAluno.GetAlunoId(id);
                if(aluno != null)
                {
                    await _servicesAluno.DeliteAluno(aluno);
                    return Ok($"Aluno de id={id} foi excluido com sucesso");
                }
                else
                {
                    return NotFound($"Aluno de id{id} não encontrado");
                }
            }
            catch (Exception)
            {

                return BadRequest("Request Invalido");
            }
        }


    }
}
