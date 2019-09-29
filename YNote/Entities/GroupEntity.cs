using System.Collections.Generic;
using YNote.Entities.Base;

namespace YNote.Entities {

    public class GroupEntity:BaseEntity {

        public string GroupName { get; set; }

        public int SpaceId { get; set; }
        public SpaceEntity Space { get; set; }

        public List<NoteEntity> Notes { get; set; } 
    }                                       
}
