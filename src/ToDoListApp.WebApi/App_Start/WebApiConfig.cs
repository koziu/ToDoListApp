using System.Linq;
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

      var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
      config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

      config.Routes.MapHttpRoute(
        "DefaultApi",
        "api/{controller}/{action}/{id}",
        new {controller = "ToDoController", id = RouteParameter.Optional}
      );
    }
  }
}