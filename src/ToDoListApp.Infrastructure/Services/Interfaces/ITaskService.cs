using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListApp.Infrastructure.Dto;

namespace ToDoListApp.Infrastructure.Services.Interfaces
{
  public interface ITaskService : IService
  {
    Task<IEnumerable<TaskDto>> GetByOwnerAsync(Guid owner);
  }
}