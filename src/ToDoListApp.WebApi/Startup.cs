﻿using System;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using Owin;
using ToDoListApp.Infrastructure.DbContext;
using ToDoListApp.Infrastructure.IoC;
using ToDoListApp.Infrastructure.Services;
using ToDoListApp.Infrastructure.Services.Interfaces;
using ToDoListApp.Web;
using ToDoListApp.Web.Providers;

[assembly: OwinStartup(typeof(Startup))]

namespace ToDoListApp.Web
{
  public class Startup
  {
    public static void Configuration(IAppBuilder app)
    {
      var config = new HttpConfiguration();
      WebApiConfig.Register(config);
      GlobalConfiguration.Configure(WebApiConfig.Register);
      var builder = new ContainerBuilder();
      builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
      builder.RegisterWebApiFilterProvider(config);
      builder.RegisterWebApiModelBinderProvider();
      builder.RegisterModule(new ContainerModule());
      builder.RegisterType<ToDoListDbContext>();
      var container = builder.Build();
      config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
      app.UseWebApi(config);
      //app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
      var authService = container.Resolve<IAuthService>();
      ConfigureOAuth(app, authService);

    }

    public static void ConfigureOAuth(IAppBuilder app, IAuthService authService)
    {
      var oAuthServerOptions = new OAuthAuthorizationServerOptions()
      {
        AllowInsecureHttp = true,
        TokenEndpointPath = new PathString("/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        Provider = new AuthServerProvider(authService)
      };

      // Token Generation
      app.UseOAuthAuthorizationServer(oAuthServerOptions);
      app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());
    }
  }
}