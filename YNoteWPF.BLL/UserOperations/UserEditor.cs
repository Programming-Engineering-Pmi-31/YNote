using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNoteWPF.DAL;
using YNoteWPF.DAL.Entities;

namespace YNoteWPF.BLL.UserOperations
{
    public class UserEditor
    {
        private static string email;
        private static string password;
        public string passwordError = "";
        public UserEditor()
        {

        }
        public UserEditor(string Email, string Password)
        {
            SetCurrentEmailAndPass(Email, Password);
        }
        static void SetCurrentEmailAndPass(string Email, string Password)
        {
            email = Email;
            password = Password;
        }

        /// <summary>
        /// Argument [parameters] must be in such order: Name, Surname, Email, Password, ConfirmPassword
        /// </summary>
        public void UpdateUser(List<string> parameters)
        {
            YNoteDbContext db = new YNoteDbContext();
            IEnumerable<UserEntity> users = from usr in db.Users
                                            where usr.Email == email && usr.Password == password
                                            select usr;
            users.First().Name = parameters[0];
            users.First().Surname = parameters[1];
            users.First().Email = parameters[2];
            if (parameters[3] != "Enter New Password" && parameters[4] != "Confirm Password")
            {
                if (parameters[3] == parameters[4])
                {
                    users.First().Password = parameters[3];
                }
                else
                {
                    passwordError = $"Passwords are not equal: {parameters[3]}  and{parameters[4]}";
                }
            }
            db.SaveChanges();
        }
        public void DeleteUser()
        {
            YNoteDbContext db = new YNoteDbContext();
            IEnumerable<UserEntity> users = from usr in db.Users
                                            where usr.Email == email && usr.Password == password
                                            select usr;
            db.Users.Remove(users.First());
            db.SaveChanges();
        }
    }
}
