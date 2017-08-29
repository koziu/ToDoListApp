using System.Linq;
using System.Web.Http.Cors;
using System.Web.Http;

namespace ToDoListApp.Web
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      // Web API configuration and services
      EnableCrossSiteRequests(config);
      // Web API routes
      config.MapHttpAttributeRoutes();

      var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
      config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);

      config.Routes.MapHttpRoute(
        "DefaultApi",
        "api/{controller}/{action}/{id}",
        new {controller = "ToDo", id = RouteParameter.Optional}
      );      
    }

    private static void EnableCrossSiteRequests(HttpConfiguration config)
    {
      var cors = new EnableCorsAttribute(
          origins: "*",
          headers: "*",
          methods: "*");
      config.EnableCors(cors);
    }
  }
}