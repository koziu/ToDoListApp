using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace ToDoListApp.Infrastructure.Services.Interfaces
{
  public interface IAuthService : IService
  {
    Task RegisterAsync(string name, string email, string password);
    Task<IdentityUser> GetAsync(string login, string password);
  }
}