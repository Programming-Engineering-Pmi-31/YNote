using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNoteWPF.DAL.Entities;
using YNoteWPF.DAL;

namespace YNoteWPF.BLL
{
    public class DataVerification
    {
        YNoteDbContext db = new YNoteDbContext();
        string nickname;
        string password;
        public bool Verification(string Nickname, string Password)
        {
            nickname = Nickname;
            password = Password;

            IQueryable<UserEntity> users = from user in db.Users
                        where user.Nickname == nickname && user.Password == password
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
    }
}
