using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoListApp.Core.Repositories
{
    public interface ITaskRepository : IRepository
    {
        Task<IEnumerable<Domain.Task>> GetAllAsync();

        Task<Domain.Task> GetAsync(Guid id);

        Task<IEnumerable<Domain.Task>> GetByOwnerAsync(Guid owner);

        Task DeleteAsync(Guid id);

        Task CreateAsync(Domain.Task task);

        Task UpdateAsync(Guid id, string title, string description, DateTime term, bool isDon);
    }
}