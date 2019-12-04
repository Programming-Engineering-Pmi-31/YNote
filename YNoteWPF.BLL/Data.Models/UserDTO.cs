using System;

namespace YNoteWPF.BLL.Data.Models
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Nickname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
    }
}