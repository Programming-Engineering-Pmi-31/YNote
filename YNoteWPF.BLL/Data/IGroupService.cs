using System.Collections.Generic;
using System.Threading.Tasks;
using YNoteWPF.DAL.Entities;

namespace YNoteWPF.BLL.Data
{
    public interface IGroupService
    {
        Task<List<GroupEntity>> GetAllAsync();

        Task<GroupEntity> GetByIdAsync(int id);
    }
}