using System;
using System.Collections.Generic;
using YNote.Entities.Base;

namespace YNote.Entities {
    public class SpaceEntity:BaseEntity {

        public string SpaceName { get; set; }
        public List<GroupEntity> Groups { get; set; } 

        public Guid AuthorId { get; set; }
        public UserEntity Author { get; set; }

        public List<NoteEntity> Notes { get; set; }
        public List<UserEntity> Users { get; set; }
    }
}