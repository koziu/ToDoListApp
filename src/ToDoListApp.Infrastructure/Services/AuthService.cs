using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNet.Identity.EntityFramework;
using ToDoListApp.Core.Domain;
using ToDoListApp.Infrastructure.Repositories;
using ToDoListApp.Infrastructure.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ToDoListApp.Infrastructure.Services
{
  public class AuthService : IAuthService
  {
    private readonly IAuthRepository _authRepository;
    private readonly IMapper _mapper;

    public AuthService(IAuthRepository authRepository, IMapper mapper)
    {
      _authRepository = authRepository;
      _mapper = mapper;
    }

    public async Task RegisterAsync(string login, string email, string password)
    {
      var user = new User(login, email, password);
      await _authRepository.RegisterAsync(user);
    }

    public async Task<IdentityUser> GetAsync(string login, string password)
    {
      return await _authRepository.FindAsync(login, password);
    }
  }
}