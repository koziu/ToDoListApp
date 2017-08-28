using Autofac;
using ToDoListApp.Infrastructure.IoC.Modules;
using ToDoListApp.Infrastructure.Mappers;

namespace ToDoListApp.Infrastructure.IoC
{
  public class ContainerModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterInstance(AutoMapperConfig.Initialize()).SingleInstance();
      builder.RegisterModule<RepositoryModule>();
      builder.RegisterModule<ServiceModule>();
    }
  }
}