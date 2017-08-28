using Autofac;
using System.Reflection;
using ToDoListApp.Core.Repositories;
using Module = Autofac.Module;

namespace ToDoListApp.Infrastructure.IoC.Modules
{
  public class RepositoryModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = typeof(RepositoryModule)
        .GetTypeInfo()
        .Assembly;

      builder.RegisterAssemblyTypes(assembly)
        .Where(x => x.IsAssignableTo<IRepository>())
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();
    }
  }
}
