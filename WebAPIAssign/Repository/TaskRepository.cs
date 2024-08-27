using AssignmentWebApi.IRepository;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using WebAPIAssign.Models;

namespace WebAPIAssign.DataContext
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _context;

        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        public ProjectTask GetTasksById(int id)
        {
            return _context.Tasks.Find(id);
        }

        public IEnumerable<ProjectTask> GetAllTasks()
        {
            return _context.Tasks.ToList();
        }

        public void AddTasks(ProjectTask task)
        {
            _context.Tasks.Add(task);
            _context.SaveChanges();
        }

        public void UpdateTasks(ProjectTask task)
        {
            _context.Tasks.Update(task);
            _context.SaveChanges();
        }

        public void DeleteTasks(int id)
        {
            var task = _context.Tasks.Find(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                _context.SaveChanges();
            }
        }

        // SubTask-related methods
        public SubTask AddSubTask(SubTask subTask)
        {
            _context.SubTasks.Add(subTask);
            _context.SaveChanges();
            return subTask;
        }

        public IEnumerable<SubTask> GetSubTasksByTaskId(int taskId)
        {
            return _context.SubTasks.Where(st => st.TaskId == taskId).ToList();
        }
    }
}

