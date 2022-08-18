using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(int id);
        Task<List<T>> GetAll();
        Task<int> Create(T obj);
        Task<int> Update(T obj);
        Task<int> Delete(int id);
    }
}
