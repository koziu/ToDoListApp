using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using ToDoListApp.Infrastructure.Dto;
using ToDoListApp.Infrastructure.Services.Interfaces;

namespace ToDoListApp.Web.Controllers
{
  public class ToDoController : ApiController
  {
    private readonly ITaskService _taskService;

    public ToDoController(ITaskService taskService)
    {
      _taskService = taskService;
    }  

    [HttpGet]
    [ActionName("getbyid")]
    public async Task<TaskDto> Get(Guid id)
    {
      return await _taskService.GetAsync(id);
    }

    [HttpGet]
    [ActionName("getall")]
    public async Task<IHttpActionResult> GetAll()
    {
      var data = await _taskService.GetAllAsync();

      return Ok(data);
    }

    [HttpGet]
    [ActionName("getbyowner")]
    public async Task<IHttpActionResult> GetByOwner(Guid owner)
    {
      var data = await _taskService.GetByOwnerAsync(owner);
      return Ok(data);
    }

    [HttpPost]
    [ActionName("add")]
    public async Task<IHttpActionResult> Add(string title, string description, DateTime term, Guid owner)
    {
      await _taskService.AddAsync(title, description, term, owner);
      return Ok();
    }

    [HttpPost]
    [ActionName("update")]
    public async Task Update(Guid id, string title, string description, DateTime term, bool isDone)
    {
      await _taskService.UpdateAsync(id, title, description, term, isDone);
    }

    [HttpPost]
    [ActionName("remove")]
    public async Task Remove(Guid id)
    {
      await _taskService.RemoveAsync(id);
    }
  }
}