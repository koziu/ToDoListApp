using System.Reflection;
using System.Web;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using ToDoListApp.Infrastructure.DbContext;
using ToDoListApp.Infrastructure.IoC;

namespace ToDoListApp.Web
{
  public class WebApiApplication : HttpApplication
  {
    protected void Application_Start()
    {
      GlobalConfiguration.Configure(WebApiConfig.Register);
      var builder = new ContainerBuilder();
      var config = GlobalConfiguration.Configuration;

      builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
      builder.RegisterWebApiFilterProvider(config);
      builder.RegisterWebApiModelBinderProvider();
      builder.RegisterModule(new ContainerModule());
      builder.RegisterType<ToDoListDbContext>().InstancePerRequest();
      var container = builder.Build();
      config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
    }
  }
}