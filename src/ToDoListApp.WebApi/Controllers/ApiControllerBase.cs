using System.Threading.Tasks;
using System.Web.Http;
using ToDoListApp.Infrastructure.Commands.Interfaces;

namespace ToDoListApp.Web.Controllers
{
  public class ApiControllerBase : ApiController
  {
    private readonly ICommandDispatcher CommandDispatcher;

    protected ApiControllerBase(ICommandDispatcher commandDispatcher)
    {
      CommandDispatcher = commandDispatcher;
    }

    protected async Task DispatchAsync<T>(T command) where T : ICommand
    {
      //if (command is IAuthenticatedCommand authenticatedCommand)
      //      {
      //  authenticatedCommand.UserId = UserId;
      //}
      await CommandDispatcher.DispatchAsync(command);
    }
  }
}