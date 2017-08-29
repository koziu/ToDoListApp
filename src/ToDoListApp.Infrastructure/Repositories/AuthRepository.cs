using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ToDoListApp.Core.Domain;
using ToDoListApp.Infrastructure.DbContext;

namespace ToDoListApp.Infrastructure.Repositories
{
  public class AuthRepository : IAuthRepository, IDisposable
  {
    private readonly ToDoListDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public AuthRepository(ToDoListDbContext context)
    {
      _context = context;
      _userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
    }

    public async Task<IdentityResult> RegisterAsync(User userModel)
    {
      var user = new IdentityUser
      {
        UserName = userModel.Login,
        Email = userModel.Email,
        Id = userModel.Id.ToString()
      };

      var result = await _userManager.CreateAsync(user, userModel.Password);

      return result;
    }

    public async Task<IdentityUser> FindAsync(string login, string password)
    {
      var user = await _userManager.FindAsync(login, password);

      return user;
    }

    public void Dispose()
    {
      _context?.Dispose();
      _userManager.Dispose();
      GC.SuppressFinalize(this);
    }
  }
}