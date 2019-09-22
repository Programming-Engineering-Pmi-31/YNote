using System;
using YNote.Domain.Entities.Base;

namespace YNote.Domain.Entities {
    public class UserEntity:BaseEntity {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Nickname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
