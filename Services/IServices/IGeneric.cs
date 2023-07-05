using CadastroAluno.Models;

namespace CadastroAluno.Services.IServices
{
    public interface IGeneric
    {
        Task<IEnumerable<T>> GetGenericAll<T>() where T : class;
        Task<T> GetGenericById<T>(int id) where T : class;
       // Task<IEnumerable<T>> GetGenericByNome<T>(string nome) where T : class;
        Task Create<T>(T entity) where T : class;
        Task Update<T>(T entity) where T : class;
        Task Delete<T>(T entity) where T : class;

    }

}
