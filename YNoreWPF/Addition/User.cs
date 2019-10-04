using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YNoreWPF.Addition {
    public class User {

        static User shared;

        public string Email { get; set; }
        public string Password { get; set; }

        public User(string email, string password) {
            Email = email;
            Password = password;
        }

        public static User getShared(string email, string password) {
            if (shared == null)
                shared = new User(email, password);
            return shared;
        }
    }
}
