using System.Collections.Generic;
using System.Threading.Tasks;
using YNoteWPF.BLL.Data.Models;

namespace YNoteWPF.BLL.Data.Interfaces
{
    public interface ISpaceService
    {
        Task<List<SpaceDTO>> GetAllSpacesAsync();

        Task<SpaceDTO> GetSpaceByIdAsync(int id);

        Task<SpaceDTO> CreateSpaceAsync(CreateSpaceDTO createSpaceDTO);

        Task<SpaceDTO> ChangeSpaceNameAsync(UpdateSpaceDTO updateSpaceDTO);

        Task<SpaceDTO> UpdateSpaceUsersAsync(UpdateSpaceDTO updateSpaceDTO);

        Task DeleteSpaceAsync(int id);
    }
}