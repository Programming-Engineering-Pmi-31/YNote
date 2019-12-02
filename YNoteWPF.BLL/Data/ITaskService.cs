using System.Collections.Generic;
using System.Threading.Tasks;
using YNoteWPF.DAL.Entities;

namespace YNoteWPF.BLL.Data
{
    public interface ITaskService
    {
        Task<List<TaskEntity>> GetAllAsync();

        Task<TaskEntity> GetByIdAsync(int id);
    }
}