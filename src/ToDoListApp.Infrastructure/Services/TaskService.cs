using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ToDoListApp.Core.Repositories;
using ToDoListApp.Infrastructure.Dto;
using ToDoListApp.Infrastructure.Services.Interfaces;
using Task = ToDoListApp.Core.Domain.Task;

namespace ToDoListApp.Infrastructure.Services
{
  public class TaskService : ITaskService
  {
    private readonly IMapper _mapper;
    private readonly ITaskRepository _taskRepository;

    public TaskService(IMapper mapper, ITaskRepository taskRepository)
    {
      _mapper = mapper;
      _taskRepository = taskRepository;
    }

    public async Task<IEnumerable<TaskDto>> GetByOwnerAsync(Guid owner)
    {
      var tasks = await _taskRepository.GetByOwnerAsync(owner);
      return _mapper.Map<IEnumerable<Task>, IEnumerable<TaskDto>>(tasks);
    }
  }
}