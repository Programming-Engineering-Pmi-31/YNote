using System;
using System.Collections.Generic;
using YNote.Domain.Entities.Base;

namespace YNote.Domain.Entities {
    public class NoteEntity:BaseEntity {
        public int GroupId { get; set; }
        public DateTimeOffset CreationTime { get; set; } 
        public int AssignedOn { get; set; }
        public List<TaskEntity> AllTasks { get; set; } 
    }
}
