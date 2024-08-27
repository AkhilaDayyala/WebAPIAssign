using Microsoft.EntityFrameworkCore;
using WebAPIAssign.Models;

namespace AssignmentWebApi.IRepository
{
    public interface ITaskRepository
    {
        ProjectTask GetTasksById(int id);
        IEnumerable<ProjectTask> GetAllTasks();
        void AddTasks(ProjectTask task);
        void UpdateTasks(ProjectTask task);
        void DeleteTasks(int id);

        // SubTask-related methods
        SubTask AddSubTask(SubTask subTask);
        IEnumerable<SubTask> GetSubTasksByTaskId(int taskId);
    }
}