using System.Collections.Generic;

namespace YNoteWPF.BLL.Data.Models
{
    public class UpdateNoteDTO
    {
        public int Id { get; set; }

        public GroupDTO Group { get; set; }

        public UserDTO AssignedUser { get; set; }

        public List<UpdateTaskDTO> Tasks { get; set; }
    }
}