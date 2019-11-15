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
    public class SpaceRepository : IRepository<SpaceEntity>
    {
        private YNoteDbContext db;

        public SpaceRepository(YNoteDbContext context)
        {
            this.db = context;
        }

        public IEnumerable<SpaceEntity> GetAll()
        {
            return db.Spaces;
        }

        public SpaceEntity GetById(object id)
        {
            return db.Spaces.Find(id);
        }

        public void Create(SpaceEntity item)
        {
            db.Spaces.Add(item);
        }

        public void Update(SpaceEntity item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<SpaceEntity> Find(Func<SpaceEntity, Boolean> predicate)
        {
            return db.Spaces.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            SpaceEntity item = db.Spaces.Find(id);
            if (item != null)
                db.Spaces.Remove(item);
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
