using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListApp.Infrastructure.Dto;

namespace ToDoListApp.Infrastructure.Services.Interfaces
{
  public interface ITaskService : IService
  {
    Task<IEnumerable<TaskDto>> GetByOwnerAsync(Guid owner);
    Task<IEnumerable<TaskDto>> GetAllAsync();
    Task<TaskDto> GetAsync(Guid id);
    Task AddAsync(string title, string description, DateTime term, Guid owner);
    Task RemoveAsync(Guid id);
    Task UpdateAsync(Guid id, string title, string description, DateTime term, bool isDone);


  }
}