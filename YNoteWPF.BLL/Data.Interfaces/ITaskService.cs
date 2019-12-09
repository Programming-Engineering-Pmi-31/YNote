using System.Collections.Generic;
using System.Threading.Tasks;
using YNoteWPF.BLL.Data.Models;

namespace YNoteWPF.BLL.Data.Interfaces
{
    public interface ITaskService
    {
        Task<List<TaskDTO>> GetAllTasksAsync();

        Task<TaskDTO> CreateTaskAsync(CreateTaskDTO dto);

        Task<TaskDTO> UpdateTaskAsync(UpdateTaskDTO dto);
    }
}