﻿using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Repositories.Implementations;
using System;
using System.Collections.Generic;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private ITaskRepository TaskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
           TaskRepository = taskRepository;
        }

        [HttpGet]
        public IActionResult GetTasks(TaskStatus? status)
        {
            try
            {
                IEnumerable<Task> tasks = TaskRepository.GetTasks(status);
                return Ok(tasks);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}