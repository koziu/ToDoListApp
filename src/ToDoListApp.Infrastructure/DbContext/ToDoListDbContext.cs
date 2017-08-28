using System.Data.Entity;
using ToDoListApp.Infrastructure.DbModels;

namespace ToDoListApp.Infrastructure.DbContext
{
  public class ToDoListDbContext : System.Data.Entity.DbContext
  {
    public ToDoListDbContext() : base("ToDoList")
    {
    }

    public DbSet<TaskDbModel> Task { get; set; }
  }
}