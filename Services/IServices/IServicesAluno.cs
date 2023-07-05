using CadastroAluno.Models;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace CadastroAluno.Services.IServices
{
    public interface IServicesAluno
    {
       
        Task<IEnumerable<AlunoModel>> GetAlunos();
        Task<AlunoModel> GetAlunoId(int id);
        Task<IEnumerable<AlunoModel>> GetAlunosByNome(string nome);
        Task CreateAluno(AlunoModel aluno);
        Task UpdateAluno(AlunoModel aluno);
        Task DeliteAluno(AlunoModel aluno);

    }
}
