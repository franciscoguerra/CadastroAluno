using CadastroAluno.Context;
using CadastroAluno.Models;
using CadastroAluno.Services.IServices;
using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CadastroAluno.Services
{
    public class AlunoService : IServicesAluno
    {
        private readonly CadastroAlunoDbContext _context;
        public AlunoService(CadastroAlunoDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<AlunoModel>> GetAlunos()
        {


            try
            {
                return _context.Alunos.ToList();
            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<AlunoModel>> GetAlunosByNome(string nome)
        {
            IEnumerable<AlunoModel> alunos;
            if (!string.IsNullOrWhiteSpace(nome))
            {
                alunos =  _context.Alunos.Where(n => n.FirstNome.Contains(nome)).ToList();
            }
            else
            {
                alunos = await GetAlunos();
            }
            return alunos;
        }
        public async Task<AlunoModel> GetAlunoId(int id)
        {
            var aluno = await _context.Alunos.FindAsync(id);
            return aluno;
        }
      


        public async Task CreateAluno(AlunoModel aluno)
        {
            _context.Alunos.Add(aluno);
            await _context.SaveChangesAsync();
        }

        
        public async Task UpdateAluno(AlunoModel aluno)
        {
            _context.Entry(aluno).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeliteAluno(AlunoModel aluno)
        {
            _context.Alunos.Remove(aluno);
            await _context.SaveChangesAsync();
        }

       
    }
}
