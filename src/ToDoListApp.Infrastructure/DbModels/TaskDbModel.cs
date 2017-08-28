using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApp.Infrastructure.DbModels
{
    [Table("Task")]
    public class TaskDbModel
    {
        [Key]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Term { get; set; }
        public Guid Owner { get; set; }
        public bool IsDone { get; set; }
    }
}