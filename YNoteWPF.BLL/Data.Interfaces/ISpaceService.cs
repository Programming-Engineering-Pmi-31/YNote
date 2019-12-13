using System.Collections.Generic;
using System.Threading.Tasks;
using YNoteWPF.BLL.Data.Models;

namespace YNoteWPF.BLL.Data.Interfaces
{
    /// <summary>
    /// Space service interface.
    /// </summary>
    public interface ISpaceService
    {
        /// <summary>
        /// Get all Spaces method
        /// </summary>
        /// <returns>All existed Spaces</returns>
        Task<List<SpaceDTO>> GetAllSpacesAsync();

        /// <summary>
        /// Get Space by id method
        /// </summary>
        /// <param name="id">Space's id.</param>
        /// <returns>Existed Space</returns>
        Task<SpaceDTO> GetSpaceByIdAsync(int id);

        /// <summary>
        /// Create new Space method
        /// </summary>
        /// <param name="createSpaceDTO">Data for creating new Space.</param>
        /// <returns>Created Space</returns>
        Task<SpaceDTO> CreateSpaceAsync(CreateSpaceDTO createSpaceDTO);

        /// <summary>
        /// Change Space name method
        /// </summary>
        /// <param name="updateSpaceDTO">Data for updating</param>
        /// <returns>Updated Space</returns>
        Task<SpaceDTO> ChangeSpaceNameAsync(UpdateSpaceDTO updateSpaceDTO);

        Task<SpaceDTO> UpdateSpaceUsersAsync(UpdateSpaceDTO updateSpaceDTO);

        Task DeleteSpaceAsync(int id);
    }
}