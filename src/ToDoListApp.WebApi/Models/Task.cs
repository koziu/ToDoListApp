﻿using System;

namespace ToDoListApp.Web.Models
{
    public class Task
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Term { get; set; }
    }
}