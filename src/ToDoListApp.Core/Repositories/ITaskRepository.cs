using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoListApp.Core.Repositories
{
    public interface ITaskRepository : IRepository
    {
        Task<IEnumerable<Domain.Task>> GetAllAsync();

        Task<Domain.Task> GetAsync(Guid id);

        Task<Domain.Task> GetByOwnerAsync(Guid owner);

        Task DeleteAsync(Guid id);

        Task CreateAsync(Domain.Task task);

        Task UpdateAsync(Domain.Task task);
    }
}