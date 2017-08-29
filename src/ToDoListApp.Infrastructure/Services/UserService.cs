using ToDoListApp.Core.Domain;
using ToDoListApp.Infrastructure.Services.Interfaces;
using Task = System.Threading.Tasks.Task;

namespace ToDoListApp.Infrastructure.Services
{
  public class UserService : IUserService
  {
    private readonly IEncrypter _encrypter;

    public UserService(IEncrypter encrypter)
    {
      _encrypter = encrypter;
    }

    public async Task RegisterAsync(string name, string surname, string email, string password)
    {
      var salt = _encrypter.GetSalt(password);
      var hash = _encrypter.GetHash(password, salt);
      var user = new User(name, surname, email, hash, salt);
    }

    public async Task LoginAsync(string email, string password)
    {
      throw new System.NotImplementedException();
    }
  }
}