using System.Collections.Generic;

namespace YNoteWPF.BLL.Data.Models
{
    public class GroupDTO
    {
        public int Id { get; set; }

        public string GroupName { get; set; }

        public SpaceDTO Space { get; set; }

        public List<NoteDTO> Notes { get; set; }
    }
}