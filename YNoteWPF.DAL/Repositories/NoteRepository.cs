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
    public class NoteRepository : IRepository<NoteEntity>
    {
        private YNoteDbContext db;

        public NoteRepository(YNoteDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<NoteEntity> GetAll()
        {
            return db.Notes;
        }

        public NoteEntity GetById(object id)
        {
            return db.Notes.Find(id);
        }

        public void Create(NoteEntity item)
        {
            db.Notes.Add(item);
        }

        public void Update(NoteEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<NoteEntity> Find(Func<NoteEntity, Boolean> predicate)
        {
            return db.Notes.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            NoteEntity item = db.Notes.Find(id);
            if (item != null)
                db.Notes.Remove(item);
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
 