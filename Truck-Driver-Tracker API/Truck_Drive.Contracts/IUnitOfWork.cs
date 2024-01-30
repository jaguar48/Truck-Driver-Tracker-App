using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Drive.Contracts
{
    public interface IUnitofWork
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int SaveChanges();
        void Dispose();
        Task<int> SaveChangesAsync();
    }
}
