using ToDoListApp.Infrastructure.Commands.Interfaces;

namespace ToDoListApp.Infrastructure.Commands.Users
{
  public class CreateUser : ICommand
  {
    public string Login { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
  }
}