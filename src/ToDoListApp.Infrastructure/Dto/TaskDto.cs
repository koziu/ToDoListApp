using System;

namespace ToDoListApp.Infrastructure.Dto
{
    public class TaskDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Term { get; set; }
        public Guid Owner { get; set; }
        public bool IsDone { get; set; }
    }
}