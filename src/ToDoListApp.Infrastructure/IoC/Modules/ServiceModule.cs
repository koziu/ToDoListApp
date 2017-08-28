using System.Reflection;
using Autofac;
using ToDoListApp.Infrastructure.Services;
using ToDoListApp.Infrastructure.Services.Interfaces;
using Module = Autofac.Module;

namespace ToDoListApp.Infrastructure.IoC.Modules
{
  public class ServiceModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      var assembly = typeof(ServiceModule)
        .GetTypeInfo()
        .Assembly;

      builder.RegisterAssemblyTypes(assembly)
        .Where(x => x.IsAssignableTo<IService>())
        .AsImplementedInterfaces()
        .InstancePerLifetimeScope();

      builder.RegisterType<Encrypter>()
        .As<IEncrypter>()
        .SingleInstance();
    }
  }
}