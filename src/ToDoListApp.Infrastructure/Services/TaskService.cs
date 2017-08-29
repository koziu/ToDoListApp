using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using ToDoListApp.Core.Repositories;
using ToDoListApp.Infrastructure.Dto;
using ToDoListApp.Infrastructure.Services.Interfaces;
using ToDoListApp.Infrastructure.DbModels;

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

    public async Task<IEnumerable<TaskDto>> GetAllAsync()
    {
      var tasks = await _taskRepository.GetAllAsync();
      return _mapper.Map<IEnumerable<Core.Domain.Task>, IEnumerable<TaskDto>>(tasks);
    }

    public async Task<TaskDto> GetAsync(Guid id)
    {
      var task = await _taskRepository.GetAsync(id);
      return _mapper.Map<Core.Domain.Task, TaskDto>(task);
    }

    public async Task<IEnumerable<TaskDto>> GetByOwnerAsync(Guid owner)
    {
      var tasks = await _taskRepository.GetByOwnerAsync(owner);
      return _mapper.Map<IEnumerable<Core.Domain.Task>, IEnumerable<TaskDto>>(tasks);
    }

    public async Task AddAsync(string title, string description, DateTime term, Guid owner)
    {
      var task = new Core.Domain.Task(title, description, term, owner);
      await _taskRepository.CreateAsync(task);
    }

    public async Task RemoveAsync(Guid id)
    {
      await _taskRepository.DeleteAsync(id);
    }

    public async Task UpdateAsync(Guid id, string title, string description, DateTime term, bool isDone)
    {      
      await _taskRepository.UpdateAsync(id, title, description, term, isDone);
    }
  }
}