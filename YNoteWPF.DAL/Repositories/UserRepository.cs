using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using YNoteWPF.DAL.Entities;
using YNoteWPF.DAL.Interfaces;


namespace YNoteWPF.DAL.Repositories
{
    public class UserRepository : IRepository<UserEntity>
    {
        private YNoteDbContext db;

        public UserRepository(YNoteDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<UserEntity> GetAll()
        {
            return db.Users;
        }

        public UserEntity GetById(object id)
        {
            return db.Users.Find(id);
        }

        public void Create(UserEntity item)
        {
            db.Users.Add(item);
        }

        public void Update(UserEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<UserEntity> Find(Func<UserEntity, Boolean> predicate)
        {
            return db.Users.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            UserEntity item = db.Users.Find(id);
            if (item != null)
                db.Users.Remove(item);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
