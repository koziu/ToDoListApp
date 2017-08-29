using System.Threading.Tasks;
using ToDoListApp.Core.Domain;
using Task = System.Threading.Tasks.Task;

namespace ToDoListApp.Core.Repositories
{
  public interface IUserRepository : IRepository
  {
    Task CreateAsync(User user);
    Task<User> GetAsync(string email);
  }
}
