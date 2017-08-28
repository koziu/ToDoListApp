using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListApp.Infrastructure.Dto;

namespace ToDoListApp.Infrastructure.Services
{
    public interface ITaskService : IService
    {
        Task<IEnumerable<TaskDto>> GetAllAsync();
        Task<TaskDto> GetAsync();
        Task<TaskDto> GetByOwnerAsync(Guid owner);
        Task SaveAsync(string title, string description, DateTime term, Guid owner);

    }
}