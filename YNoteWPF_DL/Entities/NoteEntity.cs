﻿using System;
using System.Collections.Generic;
using YNoteWPF_DL.Entities.Base;

namespace YNoteWPF_DL.Entities {
    public class NoteEntity:BaseEntity {

        public int? GroupId { get; set; }
        public GroupEntity Group { get; set; }

        public int? SpaceId { get; set; }
        public SpaceEntity Space { get; set; }

        public DateTimeOffset CreationTime { get; set; } 

        public Guid? AssignedUserId { get; set; }
        public UserEntity AssignedUser { get; set; }

        public List<TaskEntity> Tasks { get; set; } 
    }
}
