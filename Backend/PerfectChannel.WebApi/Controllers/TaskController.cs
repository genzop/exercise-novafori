using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using PerfectChannel.WebApi.Repositories.Implementations;

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
    }
}