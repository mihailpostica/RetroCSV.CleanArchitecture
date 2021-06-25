using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RetroCSV.SharedKernel;
using RetroCSV.SharedKernel.Interfaces;

namespace RetroCSV.Core.Interfaces.Persistence
{
    public interface IAsyncRepository<T> where T : BaseEntity,IAggregateRoot
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<IReadOnlyList<T>> GetPagedResponseAsync(int page, int size);
    }
}
