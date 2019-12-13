using System.Collections.Generic;

namespace YNoteWPF.BLL.Data.Models
{
    /// <summary>
    /// DTO for space.
    /// </summary>
    public class SpaceDTO
    {
        /// <summary>
        /// Entity identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Space's name
        /// </summary>
        public string SpaceName  { get; set; }

        /// <summary>
        /// Groups in space
        /// </summary>
        public List<GroupDTO> Groups { get; set; }

        /// <summary>
        /// Space's author
        /// </summary>
        public UserDTO Author { get; set; }

        /// <summary>
        /// Notes in space
        /// </summary>
        public List<NoteDTO> Notes { get; set; }

        /// <summary>
        /// Users connected to space
        /// </summary>
        public List<UserDTO> Users { get; set; }
    }
}