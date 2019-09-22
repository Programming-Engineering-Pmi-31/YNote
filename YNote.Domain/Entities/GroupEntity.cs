using System;
using System.Collections.Generic;
using YNote.Domain.Entities.Base;

namespace YNote.Domain.Entities {
    public class GroupEntity:BaseEntity {
        public string GroupName { get; set; }
        public int SpaceID { get; set; }
        public List<NoteEntity> AllNotes { get; set; } 
    }
}
