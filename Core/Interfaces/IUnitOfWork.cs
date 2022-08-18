using System;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        //public ITFSUserRepository TFSUserRepository { get; set; }
        //public ICryptography Cryptography { get; set; }
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;
        Task<int> Complete();
    }
}
