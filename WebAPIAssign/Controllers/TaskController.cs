using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPIAssign.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskRepository _taskRepository;

        public TaskController(ITaskRepository TaskRepository)
        {
            _taskRepository = TaskRepository;
        }

        [HttpGet("{id}")]
        public ActionResult<Task> GetTasksById(int id)
        {
            var task = _taskRepository.GetTasksById(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpGet]
        public ActionResult<IEnumerable<Models.ProjectTask>> GetAllTasks()
        {
            var tasks = _taskRepository.GetAllTasks();
            return Ok(tasks);
        }

        [HttpPost]
        public ActionResult<Task> AddTasks(Task task)
        {
            _taskRepository.AddTasks(task);
            return CreatedAtAction(nameof(GetTasksById), new { id = task.Id }, task);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTasks(int id, Task task)
        {
            if (id != task.Id)
            {
                return BadRequest();
            }

            _taskRepository.UpdateTasks(task);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTasks(int id)
        {
            _taskRepository.DeleteTasks(id);
            return NoContent();
        }

    }
}
