using AutoMapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using ToDoListApp.Core.Repositories;
using ToDoListApp.Infrastructure.DbContext;
using ToDoListApp.Infrastructure.DbModels;
using System.Data.Entity;

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
            catch  (Exception ex)
            {
                Debug.Print($"Błąd zapisu nowego zadania do bazy danych {ex.ToString()}");
            }     
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                var toDeleteTask = await _context.Task.FindAsync(id);
                if(toDeleteTask != null)
                {
                    _context.Task.Remove(toDeleteTask);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.Print($"Błąd usuwania zadania z bazy danych {ex.ToString()}");
            }
        }

        public async Task UpdateAsync(Core.Domain.Task task)
        {
            try
            {
                var toUpdateTask = await _context.Task.FindAsync(task.Id);
                if (toUpdateTask != null)
                {
                    var updatedTask = _mapper.Map<Core.Domain.Task, TaskDbModel>(task);
                    _context.Entry(toUpdateTask).CurrentValues.SetValues(updatedTask);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                Debug.Print($"Błąd usuwania zadania z bazy danych {ex.ToString()}");
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
                Debug.Print($"Błąd pobierania zadanń z bazy danych {ex.ToString()}");
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
                Debug.Print($"Błąd pobierania zadania z bazy danych {ex.ToString()}");
                return null;
            }          
        }

        public async Task<Core.Domain.Task> GetByOwnerAsync(Guid owner)
        {
            try
            {
                var task = await _context.Task.SingleOrDefaultAsync(t => t.Owner == owner);
                return await Task.FromResult(_mapper.Map<TaskDbModel, Core.Domain.Task>(task));
            }
            catch (Exception ex)
            {
                Debug.Print($"Błąd pobierania zadania z bazy danych {ex.ToString()}");
                return null;
            }         
        }

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}