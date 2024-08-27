using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPIAssign.Models;

namespace WebAPIAssign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubTaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;
        public SubTaskController(ITaskRepository TaskRepository)
        {
            _taskRepository = TaskRepository;
        }
        [HttpPost]
        public ActionResult<SubTask> AddSubTask(SubTask subTask)
        {
            var addedSubTask = _taskRepository.AddSubTask(subTask);
            return CreatedAtAction(nameof(GetSubTasksByTaskId), new { id = subTask.TaskId }, addedSubTask);
        }

        [HttpGet("tasks/{taskId}")]
        public ActionResult<IEnumerable<SubTask>> GetSubTasksByTaskId(int taskId)
        {
            var subTasks = _taskRepository.GetSubTasksByTaskId(taskId);
            return Ok(subTasks);
        }
    }
}
