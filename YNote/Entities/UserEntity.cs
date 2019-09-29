﻿using System;
using System.Collections.Generic;

namespace YNote.Entities {
    public class UserEntity{

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<NoteEntity> Notes { get; set; }
        public List<SpaceEntity> Spaces { get; set; }
    }
}
