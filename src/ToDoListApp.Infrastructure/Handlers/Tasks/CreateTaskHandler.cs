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
  public class CreateTaskHandler : ICommandHandler<CreateTask>
  {
    private readonly ITaskService _taskService;
    public CreateTaskHandler(ITaskService taskService)
    {
      _taskService = taskService;
    }
    public async Task HandleAsync(CreateTask command)
    {
      await _taskService.AddAsync(command.Title, command.Description, command.Term, command.Owner);
    }
  }
}
