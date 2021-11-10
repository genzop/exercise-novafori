using PerfectChannel.WebApi.Models;
using System;
using System.Collections.Generic;

namespace PerfectChannel.WebApi.Repositories.Implementations
{
    public interface ITaskRepository : IDisposable
    {
        IEnumerable<Task> GetTasks();
        IEnumerable<Task> GetTasks(TaskStatus status);
        Task GetTask(int id);
        void InsertTask(Task task);
        void UpdateTask(Task task);
        void Save();
    }
}
