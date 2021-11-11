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
        public IActionResult GetAll(TaskStatus? status)
        {
            try
            {
                List<TaskDto> tasks = TaskRepository.GetAll(status)
                                                    .Select(x => new TaskDto 
                                                    { 
                                                        Id = x.Id , 
                                                        Description = x.Description, 
                                                        Status = (int)x.Status 
                                                    })
                                                    .ToList();

                return Ok(tasks);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult Insert(TaskDto dto)
        {
            try
            {
                Task task = new Task();
                task.Description = dto.Description;
                task.Status = TaskStatus.Pending;

                TaskRepository.Insert(task);
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
        public IActionResult Update(int id)
        {
            try
            {
                Task task = TaskRepository.GetById(id);

                if(task == null)
                {
                    return NotFound();
                }

                task.Status = task.Status == TaskStatus.Pending ? TaskStatus.Completed : TaskStatus.Pending;
                TaskRepository.Save();

                TaskDto dto = new TaskDto();
                dto.Id = task.Id;
                dto.Description = task.Description;
                dto.Status = Convert.ToInt32(task.Status);

                return Ok(dto);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}