using System;

namespace ToDoListApp.Core.Domain
{
    public class Task
    {
        public Guid Id { get; protected set; }
        public string Title { get; protected set; }
        public string Description { get; protected set; }
        public DateTime Term { get; protected set; }
        public Guid Owner { get; protected set; }
        public bool IsDone { get; set; }

        public Task(string title, string description, DateTime term, Guid owner)
        {
            Id = Guid.NewGuid();
            SetTitle(title);
            SetDescription(description);
            SetTerm(term);
            SetOwner(owner);
        }

        public void SetTitle(string title)
        {
            Title = title;
        }

        public void SetDescription(string description)
        {
            Description = description;
        }

        public void SetTerm(DateTime term)
        {
            Term = term;
        }

        public void SetOwner(Guid owner)
        {
            Owner = owner;
        }
    }
}