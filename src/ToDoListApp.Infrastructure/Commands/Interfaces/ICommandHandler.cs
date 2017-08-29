using System.Threading.Tasks;

namespace ToDoListApp.Infrastructure.Commands.Interfaces
{
  public interface ICommandHandler<T> where T : ICommand
  {
    Task HandleAsync(T command);
  }
}
