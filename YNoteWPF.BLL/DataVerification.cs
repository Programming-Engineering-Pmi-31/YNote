using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNoteWPF.DAL;
namespace YNoteWPF.BLL
{
    class DataVerification
    {
        public void GetUserData(string nickName, string password)
        {
            //using ()
            //{

            //}
            YNoteDbContext db = new YNoteDbContext();
            foreach (var item in db.Users)
            {

            }
        }
    }
}
