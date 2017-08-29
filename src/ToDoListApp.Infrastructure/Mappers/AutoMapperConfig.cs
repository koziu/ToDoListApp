using AutoMapper;
using ToDoListApp.Core.Domain;
using ToDoListApp.Infrastructure.DbModels;
using ToDoListApp.Infrastructure.Dto;

namespace ToDoListApp.Infrastructure.Mappers
{
  public class AutoMapperConfig
  {
    public static IMapper Initialize()
     => new MapperConfiguration(config =>
     {
       config.CreateMap<Task, TaskDto>();
       config.CreateMap<TaskDbModel, Task>();
       config.CreateMap<Task, TaskDbModel>();
       config.CreateMap<User, UserDto>();
     }).CreateMapper();
  }
}