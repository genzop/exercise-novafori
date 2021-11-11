using PerfectChannel.WebApi.Models;
using System;
using System.Collections.Generic;

namespace PerfectChannel.WebApi.Repositories.Implementations
{
    public interface ITaskRepository : IDisposable
    {
        IEnumerable<Task> GetAll(TaskStatus? status);
        Task GetById(int id);
        void Insert(Task task);
        void Update(Task task);
        void Save();
    }
}
