using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoListApp.Infrastructure.Commands.Interfaces;
using ToDoListApp.Infrastructure.Commands.Tasks;
using ToDoListApp.Infrastructure.Services.Interfaces;

namespace ToDoListApp.Infrastructure.Handlers.Tasks
{
  public class RemoveTaskHandler : ICommandHandler<RemoveTask>
  {
    private readonly ITaskService _taskService;

    public RemoveTaskHandler(ITaskService taskService)
    {
      _taskService = taskService;
    }
    public async Task HandleAsync(RemoveTask command)
    {
      await _taskService.RemoveAsync(command.Id);
    }
  }
}
