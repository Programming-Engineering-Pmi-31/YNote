using System.Collections.Generic;

namespace YNoteWPF.BLL.Data.Models
{
    public class UpdateSpaceDTO
    {
        public int Id { get; set; }

        public string SpaceName { get; set; }

        public List<GroupDTO> Groups { get; set; }

        public List<NoteDTO> Notes { get; set; }

        public List<UserDTO> Users { get; set; }
    }
}