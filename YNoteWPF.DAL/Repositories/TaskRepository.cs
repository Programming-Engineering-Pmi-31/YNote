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
    public class TaskRepository : IRepository<TaskEntity>
    {
        private YNoteDbContext db;

        public TaskRepository(YNoteDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<TaskEntity> GetAll()
        {
            return db.Tasks;
        }

        public TaskEntity GetById(object id)
        {
            return db.Tasks.Find(id);
        }

        public void Create(TaskEntity item)
        {
            db.Tasks.Add(item);
        }

        public void Update(TaskEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<TaskEntity> Find(Func<TaskEntity, Boolean> predicate)
        {
            return db.Tasks.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            TaskEntity item = db.Tasks.Find(id);
            if (item != null)
                db.Tasks.Remove(item);
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
