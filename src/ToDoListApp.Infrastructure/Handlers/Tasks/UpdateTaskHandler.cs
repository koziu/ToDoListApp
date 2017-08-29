using System;
using System.Threading.Tasks;
using ToDoListApp.Infrastructure.Commands.Interfaces;
using ToDoListApp.Infrastructure.Commands.Tasks;
using ToDoListApp.Infrastructure.Services.Interfaces;

namespace ToDoListApp.Infrastructure.Handlers.Tasks
{
  public class UpdateTaskHandler : ICommandHandler<UpdateTask>
  {
    private readonly ITaskService _taskService;

    public UpdateTaskHandler(ITaskService taskService)
    {
      _taskService = taskService;
    }

    public async Task HandleAsync(UpdateTask command)
    {
      await _taskService.UpdateAsync(command.Id, command.Title, command.Description, command.Term, command.IsDone);
    }
  }
}