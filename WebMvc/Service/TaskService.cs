using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebMvc.Models;
using WebMvc.Data;
using DomainModel;

namespace WebMvc.Service
{
    public interface ITaskService
    {
        Task<List<MyTask>> GetAllTasksAsync();
        Task<MyTask?> FindTaskByIDAsync(int id);
        Task UpdateTaskByIDAsync(int id, string title, string content, DateTime dueDate);
        Task CreateTaskAsync(TaskEditModel model);
    }

    public class TaskService : ITaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MyTask>> GetAllTasksAsync()
        {
            return await _context.Tasks
                .Select(t => new MyTask(t.Id, t.Title, t.Content, t.DueDate))
                .ToListAsync();
        }

        public async Task<MyTask?> FindTaskByIDAsync(int id)
        {
            var taskEntity = await _context.Tasks.FindAsync(id);
            return taskEntity != null ? new MyTask(taskEntity.Id, taskEntity.Title, taskEntity.Content, taskEntity.DueDate) : null;
        }

        public async Task UpdateTaskByIDAsync(int id, string title, string content, DateTime dueDate)
        {
            var taskEntity = await _context.Tasks.FindAsync(id);
            if (taskEntity != null)
            {
                taskEntity.Title = title;
                taskEntity.Content = content;
                taskEntity.DueDate = dueDate;
                await _context.SaveChangesAsync();
            }
        }

        public async Task CreateTaskAsync(TaskEditModel model)
        {
            var taskEntity = new TaskEntity
            {
                Title = model.Title,
                Content = model.Content,
                DueDate = model.DueDate
            };
            _context.Tasks.Add(taskEntity);
            await _context.SaveChangesAsync();
        }
    }
}
