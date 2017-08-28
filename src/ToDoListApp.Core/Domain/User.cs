using System;

namespace ToDoListApp.Core.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; protected set; }
        public string Surname { get; protected set; }
        public string Email { get; protected set; }

        public User(string name, string surname, string email)
        {
            Id = Guid.NewGuid();
            SetName(name);
            SetSurname(surname);
            SetEmail(email);
        }

        public void SetEmail(string email)
        {
            Email = email;
        }

        public void SetSurname(string surname)
        {
            Surname = surname;
        }

        public void SetName(string name)
        {
            Name = name;
        }
    }
}