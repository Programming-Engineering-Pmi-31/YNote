using System;
using System.Collections.Generic;

namespace YNoteWPF.BLL.Data.Models
{
    public class CreateNoteDTO
    {

        public SpaceDTO Space { get; set; }

        public DateTimeOffset CreationTime { get; set; }

        public List<CreateTaskDTO> Tasks { get; set; }
    }
}