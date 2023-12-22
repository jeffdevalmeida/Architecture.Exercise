using BTG.Task.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Application.Repository
{
    public interface IReadWriteRepository<T> where T : class, IAggregator
    {
        Task<T?> GetAsync(Guid id);
        Task<T> SaveAsync(T model);
        System.Threading.Tasks.Task DeleteAsync(Guid id);
    }
}
