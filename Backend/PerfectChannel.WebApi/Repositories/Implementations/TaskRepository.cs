using Microsoft.EntityFrameworkCore;
using PerfectChannel.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfectChannel.WebApi.Repositories.Implementations
{
    public class TaskRepository : ITaskRepository, IDisposable
    {
        private PerfectChannelContext Context;

        public TaskRepository(PerfectChannelContext context)
        {
            Context = context;
        }

        public IEnumerable<Task> GetTasks(TaskStatus? status)
        {
            return Context.Task.Where(task => status == null || task.Status == status).ToList();
        }

        public Task GetTaskById(int id)
        {
            return Context.Task.Find(id);
        }

        public void InsertTask(Task task)
        {
            Context.Task.Add(task);
        }

        public void UpdateTask(Task task)
        {
            Context.Entry(task).State = EntityState.Modified;
        }

        public void Save()
        {
            Context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
