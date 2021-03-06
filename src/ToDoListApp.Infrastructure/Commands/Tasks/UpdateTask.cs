﻿using System;
using ToDoListApp.Infrastructure.Commands.Interfaces;

namespace ToDoListApp.Infrastructure.Commands.Tasks
{
  public class UpdateTask : ICommand
  {
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Term { get; set; }
    public bool IsDone { get; set; }
  }
}