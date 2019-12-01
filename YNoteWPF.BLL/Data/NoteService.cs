using System;
using System.Collections.Generic;
using YNoteWPF.DAL;
using YNoteWPF.DAL.Entities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace YNoteWPF.BLL.Data
{
    public class NoteService : INoteService
    {
        private Func<YNoteDbContext> _contextCreator;

        public NoteService(Func<YNoteDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<List<NoteEntity>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Notes.AsNoTracking().ToListAsync();
            }
        }

        public Task<NoteEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
