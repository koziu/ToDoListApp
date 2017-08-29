using System;
using ToDoListApp.Infrastructure.Commands.Interfaces;

namespace ToDoListApp.Infrastructure.Commands.Tasks
{
  public class RemoveTask : ICommand
  {
    public Guid Id { get; set; }
  }
}