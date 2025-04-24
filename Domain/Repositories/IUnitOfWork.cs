using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        ITicketRepository TicketRepository { get; }
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class;

        Task<int> SaveChanges();

        Task<bool> SaveChangesReturnBool();
    }

}
