using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNoteWPF.DAL.Entities;
using YNoteWPF.DAL;
using System.IO;
using System.Windows.Media;
using System.Windows.Controls;

namespace YNoteWPF.BLL
{
    public class UserData
    {
        YNoteDbContext db = new YNoteDbContext();
        string email; // should be deleted?
        string password; // should be deleted?
        FieldsConditions fieldsValidation = new FieldsConditions();
        public string ValidationErrors { get; private set; }
        //private void SeeValidationErrorsInFile()
        //{
        //    using (FileStream stream = new FileStream(")
        //    {

        //    }
        //}
        public bool Verification(string Email, string Password)
        {
            email = Email;
            password = Password;

            IQueryable<UserEntity> users = from user in db.Users
                                           where user.Email == email && user.Password == password
                                           select user;
            if (users.Any())
            {
                // list has at least one item
                return true;
            }
            return false;
        }
        public void SaveChangesForUser()
        {
            //db.SaveChanges();
        }
        public void RegisterWithoutAllNecessaryTests(List<string> parameters, Button regButton)
        {
            // tests only on password equality and check if the user with such email exists to prevent
            // of adding to db the same user (with such email)
            if (parameters[4] != parameters[5])
            {
                throw new Exception("Passwords do not match");
            }
            UserEntity user = new UserEntity()
            {
                Id = Guid.NewGuid(),
                Name = parameters[0],
                Surname = parameters[1],
                Nickname = parameters[2],
                Email = parameters[3],
                Password = parameters[4]
            };
            var inTable = db.Users.Where(x => x.Email == user.Email);
            if (!inTable.Any())
            {
                db.Users.Add(user);
                db.SaveChanges();
                regButton.BorderBrush = Brushes.Green;
            }
            else
            {
                regButton.BorderBrush = Brushes.Red;
            }
        }
    }
}
