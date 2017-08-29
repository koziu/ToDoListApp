using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ToDoListApp.Infrastructure.Dto;
using ToDoListApp.Infrastructure.Services.Interfaces;

namespace ToDoListApp.Web.Controllers
{
  public class ToDoListController : ApiController
  {
    private readonly ITaskService _taskService;

    public ToDoListController(ITaskService taskService)
    {
      _taskService = taskService;
    }

    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    [HttpGet]
    [ActionName("getbyowner")]
    public async Task<IEnumerable<TaskDto>> GetByOwnerAsync(Guid owner)
    {
      return await _taskService.GetByOwnerAsync(owner);
    }
  }
}