using CadastroAluno.Context;
using CadastroAluno.Models;
using CadastroAluno.Services.IServices;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CadastroAluno.Services
{
    public class GenericServices : IGeneric
    {
        private readonly CadastroAlunoDbContext _context;
        public GenericServices(CadastroAlunoDbContext context)
        {
            _context = context;  
        }




        public async Task<T> GetGenericById<T>(int id) where T : class
        {
            var objects = await _context.Set<T>().FindAsync(id);
            return objects;
        }   
      

        public async Task<IEnumerable<T>> GetGenericAll<T>() where T : class 
        {
            try
            {
                return  _context.Set<T>().ToList();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task Create<T>(T entity) where T : class
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
        }


        public async Task Update<T>(T entity) where T : class
        {
            _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete<T>(T entity) where T : class
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

    }
}

