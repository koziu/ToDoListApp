using System.Net;
using System.Web.Http;

namespace ToDoListApp.Web.Controllers
{ 
  public class TokenController : ApiController
  {
    [AllowAnonymous]
    public string Get(string email, string password)
    {
      if (CheckUser(email, password))
      {
        return JwtManager.GenerateToken(email);
      }

      throw new HttpResponseException(HttpStatusCode.Unauthorized);
    }

    public bool CheckUser(string username, string password)
    {
      // should check in the database
      return true;
    }
  }
}