using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PerfectChannel.WebApi.Dtos;
using PerfectChannel.WebApi.Models;
using PerfectChannel.WebApi.Repositories.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerfectChannel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowOrigin")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private ITaskRepository TaskRepository;

        public TasksController(ITaskRepository taskRepository)
        {
           TaskRepository = taskRepository;
        }

        [HttpGet]
        public IActionResult GetTasks(TaskStatus? status)
        {
            try
            {
                IEnumerable<TaskDto> tasks = TaskRepository.GetTasks(status)
                                                           .Select(x => new TaskDto 
                                                           { 
                                                               Id = x.Id , 
                                                               Description = x.Description, 
                                                               Status = (int)x.Status 
                                                           });

                return Ok(tasks);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult InsertTask(TaskDto dto)
        {
            try
            {
                Task task = new Task();
                task.Description = dto.Description;
                task.Status = TaskStatus.Pending;

                TaskRepository.InsertTask(task);
                TaskRepository.Save();

                dto.Id = task.Id;
                dto.Status = (int)task.Status;

                return Ok(dto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public IActionResult UpdateTask(int id)
        {
            try
            {
                Task task = TaskRepository.GetTaskById(id);

                if(task == null)
                {
                    return NotFound();
                }

                task.Status = task.Status == TaskStatus.Pending ? TaskStatus.Completed : TaskStatus.Pending;
                TaskRepository.Save();

                TaskDto response = new TaskDto();
                response.Id = task.Id;
                response.Description = task.Description;
                response.Status = Convert.ToInt32(task.Status);

                return Ok(task);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}