using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using ToDoListApp.Infrastructure.Commands.Interfaces;
using ToDoListApp.Infrastructure.Commands.Tasks;
using ToDoListApp.Infrastructure.Dto;
using ToDoListApp.Infrastructure.Services.Interfaces;

namespace ToDoListApp.Web.Controllers
{
  public class ToDoController : ApiControllerBase
  {
    private readonly ITaskService _taskService;

    public ToDoController(ICommandDispatcher commandDispatcher, ITaskService taskService) : base(commandDispatcher)
    {
      _taskService = taskService;
    }  

    [HttpGet]
    [ActionName("getbyid")]
    public async Task<IHttpActionResult> Get(Guid id)
    {
      var data = await _taskService.GetAsync(id);
      if (data == null) NotFound();     
      return Json(data);
    }

    [HttpGet]
    [ActionName("getall")]
    public async Task<IHttpActionResult> GetAll()
    {
      var data = await _taskService.GetAllAsync();
      if(data != null) NotFound();    
      return Json(data);
    }

    [HttpGet]
    [ActionName("getbyowner")]
    public async Task<IHttpActionResult> GetByOwner(Guid owner)
    {
      var data = await _taskService.GetByOwnerAsync(owner);
      if (data != null) NotFound();
      return Json(data);
    }

    [HttpPost]
    [ActionName("add")]
    public async Task<IHttpActionResult> Add([FromBody]CreateTask command)
    {
      await DispatchAsync(command);
      return Ok();
    }

    [HttpPost]
    [ActionName("update")]
    public async Task<IHttpActionResult> Update([FromBody]UpdateTask command)
    {
      await DispatchAsync(command);
      return Ok();
    }

    [HttpPost]
    [ActionName("remove")]
    public async Task Remove([FromBody]RemoveTask command)
    {
      await DispatchAsync(command);
    }
  }
}