using System;
using System.Threading.Tasks;
using ToDoListApp.Infrastructure.Commands.Interfaces;
using ToDoListApp.Infrastructure.Commands.Users;
using ToDoListApp.Infrastructure.Services.Interfaces;

namespace ToDoListApp.Infrastructure.Handlers.Users
{
  public class CreateUserHandler : ICommandHandler<CreateUser>
  {
    private readonly IAuthService _authService;

    public CreateUserHandler(IAuthService authService)
    {
      _authService = authService;
    }

    public async Task HandleAsync(CreateUser command)
    {
      await _authService.RegisterAsync(command.Login, command.Email, command.Password);
    }
  }
}