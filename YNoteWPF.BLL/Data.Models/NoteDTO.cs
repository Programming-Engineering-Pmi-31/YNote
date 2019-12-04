using System;
using System.Collections.Generic;

namespace YNoteWPF.BLL.Data.Models
{
    public class NoteDTO
    {
        public int Id { get; set; }

        public GroupDTO Group { get; set; } 

        public SpaceDTO Space { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public UserDTO AssignedUser { get; set; }

        public List<TaskDTO> Tasks { get; set; }
    }
}