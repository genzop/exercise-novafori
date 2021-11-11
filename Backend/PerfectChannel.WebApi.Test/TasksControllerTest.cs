using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using PerfectChannel.WebApi.Controllers;
using PerfectChannel.WebApi.Dtos;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Repositories.Implementations;
using System;
using System.Collections.Generic;

namespace PerfectChannel.WebApi.Test
{
    [TestFixture]
    public class TasksControllerTest
    {
        private PerfectChannelContext Context;
        private ITaskRepository Repository;
        private TasksController Controller;

        [SetUp]
        public void SetUp()
        {
            string connectionstring = "Server=(local);Database=PerfectChannel;Trusted_Connection=True;MultipleActiveResultSets=true";
            var optionsBuilder = new DbContextOptionsBuilder<PerfectChannelContext>();
            optionsBuilder.UseSqlServer(connectionstring);

            Context = new PerfectChannelContext(optionsBuilder.Options);
            Repository = new TaskRepository(Context);
            Controller = new TasksController(Repository);
        }

        [Test]
        public async System.Threading.Tasks.Task GetAll()
        {
            int count = await Context.Task.CountAsync();

            OkObjectResult result = Controller.GetAll(null) as OkObjectResult;
            Assert.NotNull(result);

            List<TaskDto> tasks = result.Value as List<TaskDto>;
            Assert.NotNull(tasks);

            Assert.AreEqual(count, tasks.Count);
        }

        [Test]
        public void Insert()
        {
            TaskDto task = new TaskDto();
            task.Description = "Test";
            task.Status = Convert.ToInt32(TaskStatus.Pending);

            OkObjectResult result = Controller.Insert(task) as OkObjectResult;
            Assert.NotNull(result);

            TaskDto created = result.Value as TaskDto;
            Assert.NotNull(created);

            task.Id = created.Id;

            Assert.AreEqual(task, created);
        }

        [Test]
        public void Update()
        {
            TaskDto task = new TaskDto();
            task.Description = "Test";
            task.Status = Convert.ToInt32(TaskStatus.Pending);

            OkObjectResult result = Controller.Insert(task) as OkObjectResult;
            task = result.Value as TaskDto;

            OkObjectResult result2 = Controller.Update(task.Id) as OkObjectResult;
            Assert.NotNull(result2);

            TaskDto updated = result2.Value as TaskDto;
            Assert.NotNull(updated);

            Assert.AreNotEqual(task.Status, updated.Status);
        }
    }
}
