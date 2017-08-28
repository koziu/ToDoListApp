using System.Threading.Tasks;

namespace ToDoListApp.Infrastructure.Services.Interfaces
{
  public interface IUserService : IService
  {
    Task RegisterAsync(string name, string surname, string email, string password);
    Task LoginAsync(string email, string password);
  }
}