using System.Net.Http.Headers;
using System.Web.Http;

namespace ToDoListApp.Web
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services

      // Web API routes
      config.MapHttpAttributeRoutes();
      config.Formatters.JsonFormatter.SerializerSettings.Formatting =
        Newtonsoft.Json.Formatting.Indented;

      config.Routes.MapHttpRoute(
        "DefaultApi",
        "api/{controller}/{id}",
        new {controller = "todolist", id = RouteParameter.Optional}
      );
    }
  }
}