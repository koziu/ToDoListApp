using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ToDoListApp.Core.Repositories;
using ToDoListApp.Infrastructure.DbContext;
using ToDoListApp.Infrastructure.DbModels;

namespace ToDoListApp.Infrastructure.Repositories
{
  public class TaskRepository : ITaskRepository, IDisposable
  {
    private readonly ToDoListDbContext _context;
    private readonly IMapper _mapper;

    public TaskRepository(ToDoListDbContext context, IMapper mapper)
    {
      _context = context;
      _mapper = mapper;
    }

    public async Task CreateAsync(Core.Domain.Task task)
    {
      try
      {
        var taskDbModel = _mapper.Map<Core.Domain.Task, TaskDbModel>(task);
        _context.Task.Add(taskDbModel);
        await _context.SaveChangesAsync();
      }
      catch (Exception ex)
      {
        Debug.Print($"Błąd zapisu nowego zadania do bazy danych {ex}");
      }
    }

    public async Task DeleteAsync(Guid id)
    {
      try
      {
        var toDeleteTask = await _context.Task.FindAsync(id);
        if (toDeleteTask != null)
        {
          _context.Task.Remove(toDeleteTask);
          await _context.SaveChangesAsync();
        }
      }
      catch (Exception ex)
      {
        Debug.Print($"Błąd usuwania zadania z bazy danych {ex}");
      }
    }

    public async Task UpdateAsync(Guid id, string title, string description, DateTime term, bool isDone)
    {
      try
      {
        var toUpdateTask = await _context.Task.FindAsync(id);
        toUpdateTask.Title = title;
        toUpdateTask.Description = description;
        toUpdateTask.Term = term;
        toUpdateTask.IsDone = isDone;

        if (toUpdateTask != null)
        {
          _context.Task.Attach(toUpdateTask);
          _context.Entry(toUpdateTask).Property(p => p.Title).IsModified = true;
          _context.Entry(toUpdateTask).Property(p => p.Description).IsModified = true;
          _context.Entry(toUpdateTask).Property(p => p.Term).IsModified = true; 
          _context.Entry(toUpdateTask).Property(p => p.IsDone).IsModified = true; 

          await _context.SaveChangesAsync();
        }
      }
      catch (Exception ex)
      {
        Debug.Print($"Błąd usuwania zadania z bazy danych {ex}");
      }
    }

    public async Task<IEnumerable<Core.Domain.Task>> GetAllAsync()
    {
      try
      {
        var tasks = await _context.Task.ToListAsync();
        return await Task.FromResult(_mapper.Map<IEnumerable<TaskDbModel>, IEnumerable<Core.Domain.Task>>(tasks));
      }
      catch (Exception ex)
      {
        Debug.Print($"Błąd pobierania zadanń z bazy danych {ex}");
        return null;
      }
    }

    public async Task<Core.Domain.Task> GetAsync(Guid id)
    {
      try
      {
        var task = await _context.Task.SingleOrDefaultAsync(t => t.Id == id);
        return await Task.FromResult(_mapper.Map<TaskDbModel, Core.Domain.Task>(task));
      }
      catch (Exception ex)
      {
        Debug.Print($"Błąd pobierania zadania z bazy danych {ex}");
        return null;
      }
    }

    public async Task<IEnumerable<Core.Domain.Task>> GetByOwnerAsync(Guid owner)
    {
      try
      {
        var task = await _context.Task.Where(t => t.Owner == owner).ToListAsync();
        return await Task.FromResult(_mapper.Map<IEnumerable<TaskDbModel>, IEnumerable<Core.Domain.Task>>(task));
      }
      catch (Exception ex)
      {
        Debug.Print($"Błąd pobierania zadania z bazy danych {ex}");
        return null;
      }
    }

    public void Dispose()
    {
      _context?.Dispose();
      GC.SuppressFinalize(this);
    }
  }
}