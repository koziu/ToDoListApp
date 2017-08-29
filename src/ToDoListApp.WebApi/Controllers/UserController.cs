using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using ToDoListApp.Infrastructure.Commands.Interfaces;
using ToDoListApp.Infrastructure.Commands.Users;
using ToDoListApp.Infrastructure.Services.Interfaces;

namespace ToDoListApp.Web.Controllers
{
  public class UserController : ApiControllerBase
  {
    private readonly IAuthService _authService;

    public UserController(IAuthService authService, ICommandDispatcher commandDispatcher) : base(commandDispatcher)
    {
      _authService = authService;
    }

    [AllowAnonymous]
    [ActionName("register")]
    public async Task<IHttpActionResult> Register([FromBody]CreateUser command)
    {
      await DispatchAsync(command);
      return Ok();
    }
  }
}
