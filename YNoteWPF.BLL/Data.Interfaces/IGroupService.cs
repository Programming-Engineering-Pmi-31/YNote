using System.Collections.Generic;
using System.Threading.Tasks;
using YNoteWPF.BLL.Data.Models;

namespace YNoteWPF.BLL.Data.Interfaces
{
    public interface IGroupService
    {
        Task<List<GroupDTO>> GetAllAsync();

        Task<GroupDTO> GetByIdAsync(int id);
    }
}