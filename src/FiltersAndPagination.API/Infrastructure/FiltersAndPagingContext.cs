using FiltersAndPagination.API.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FiltersAndPagination.API.Infrastructure
{
    public class FiltersAndPaginationContext : DbContext
    {
        public DbSet<ToDo> ToDos { get; set; }
        public DbSet<Task> Tasks { get; set; }

        public FiltersAndPaginationContext(DbContextOptions<FiltersAndPaginationContext> options)
            : base(options) { }

        private FiltersAndPaginationContext()
            : base() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            IList<ToDo> toDos = new List<ToDo>();
            IList<Task> tasks = new List<Task>();

            int taskId = 1;

            for (int i = 0; i < 50; i++)
            {
                ToDo todo = new ToDo
                {
                    Id = i + 1,
                    Name = $"To-Do List {i + 1}"
                };

                toDos.Add(todo);

                Task task = new Task
                {
                    Id = taskId++,
                    IsFinished = true,
                    Description = $"Task {taskId}",
                    FinishedDate = DateTime.Now,
                    ToDoId = todo.Id
                };

                Task task2 = new Task
                {
                    Id = taskId++,
                    IsFinished = true,
                    Description = $"Task {taskId}",
                    FinishedDate = DateTime.Now,
                    ToDoId = todo.Id
                };

                tasks.Add(task);
                tasks.Add(task2);
            }

            modelBuilder.Entity<ToDo>().HasData(toDos);
            modelBuilder.Entity<Task>().HasData(tasks);
        }
    }
}
