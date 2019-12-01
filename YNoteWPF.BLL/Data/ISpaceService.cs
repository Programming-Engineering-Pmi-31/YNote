using System.Collections.Generic;
using System.Threading.Tasks;
using YNoteWPF.DAL.Entities;

namespace YNoteWPF.BLL.Data
{
    public interface ISpaceService
    {
        Task<List<SpaceEntity>> GetAllAsync();

        Task<SpaceEntity> GetByIdAsync(int id);
    }
}