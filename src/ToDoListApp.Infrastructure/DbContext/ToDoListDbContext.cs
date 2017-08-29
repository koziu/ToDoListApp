using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using ToDoListApp.Infrastructure.DbModels;

namespace ToDoListApp.Infrastructure.DbContext
{
  public class ToDoListDbContext : IdentityDbContext<IdentityUser>
  {
    public ToDoListDbContext() : base("ToDoList")
    {
    }

    public DbSet<TaskDbModel> Task { get; set; }
  }
}