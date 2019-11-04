using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YNoteWPF_DL.Entities;
using YNoteWPF_DL.Interfaces;

namespace YNoteWPF_DL.Repositories
{
    public class GroupRepository : IRepository<GroupEntity>
    {
        private YNoteDbContext db;

        public GroupRepository(YNoteDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<GroupEntity> GetAll()
        {
            return db.Groups;
        }

        public GroupEntity GetById(object id)
        {
            return db.Groups.Find(id);
        }

        public void Create(GroupEntity item)
        {
            db.Groups.Add(item);
        }

        public void Update(GroupEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<GroupEntity> Find(Func<GroupEntity, Boolean> predicate)
        {
            return db.Groups.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            GroupEntity item = db.Groups.Find(id);
            if (item != null)
                db.Groups.Remove(item);
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
