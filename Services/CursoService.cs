using CadastroAluno.Context;
using CadastroAluno.Models;
using CadastroAluno.Services.IServices;
using Microsoft.Extensions.Logging;
using System.Data.Entity;

namespace CadastroAluno.Services
{
    public class CursoService : IServiceCurso
    {
        private readonly CadastroAlunoDbContext _contextCurso;
        private readonly ILogger _logger;
        public CursoService(CadastroAlunoDbContext contextCurso, ILogger<CursoService> logger)
        {
            _contextCurso = contextCurso;
            _logger = logger;

        }

        public async Task<IEnumerable<CursoModel>> GetCursos()
        {
            try
            {
                return await _contextCurso.Cursos.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter cursos!!");
                throw;
            }
        }


        public async Task<IEnumerable<CursoModel>> GetCursoName(string name)
        {
            IEnumerable<CursoModel> curso;
            if(!string.IsNullOrEmpty(name))
            {
                curso = _contextCurso.Cursos.Where(n=>n.Nome.Contains(name)).ToList();
            }
            else
            {
                curso = await GetCursos();
            }

            return curso;
        }

        public async Task<CursoModel> GetCursoId(int id)
        {
            var curso = await _contextCurso.Cursos.FindAsync(id);
            return curso;
        }
        public async Task CreateCurso(CursoModel curso)
        {
            _contextCurso.Cursos.Add(curso);
            await _contextCurso.SaveChangesAsync(); 
        }

      
        public async Task UpdateCurso(CursoModel curso)
        {
           _contextCurso.Entry(curso).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _contextCurso.SaveChangesAsync();
        }

        public async Task DeleteCurso(CursoModel curso)
        {
            _contextCurso.Cursos.Remove(curso);
           await _contextCurso.SaveChangesAsync();
        }
    }
}
