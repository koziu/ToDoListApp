using System;

namespace ToDoListApp.Core.Domain
{
  public class User
  {
    public Guid Id { get; set; }
    public string Login { get; protected set; }
    public string Email { get; protected set; }
    public string Password { get; protected set; }


    public User(string login, string email, string password)
    {
      Id = Guid.NewGuid();
      SetLogin(login);
      SetEmail(email);
      Password = password;
    }

    public void SetEmail(string email)
    {
      Email = email;
    }

    public void SetLogin(string name)
    {
      Login = name;
    }
  }
}