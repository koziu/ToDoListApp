using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ToDoListApp.Core.Domain;
using ToDoListApp.Core.Repositories;

namespace ToDoListApp.Infrastructure.Repositories
{
  public interface IAuthRepository : IRepository
  {
    Task<IdentityResult> RegisterAsync(User userModel);
    Task<IdentityUser> FindAsync(string userName, string password);
  }
}