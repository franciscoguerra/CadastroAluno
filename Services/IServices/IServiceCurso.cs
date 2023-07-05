using CadastroAluno.Models;

namespace CadastroAluno.Services.IServices
{
    public interface IServiceCurso
    {
        Task<IEnumerable<CursoModel>> GetCursos();
        Task<CursoModel> GetCursoId(int id);
        Task<IEnumerable<CursoModel>> GetCursoName(string name);
        Task CreateCurso(CursoModel curso);
        Task UpdateCurso(CursoModel curso);
        Task DeleteCurso(CursoModel curso);
    }
}
