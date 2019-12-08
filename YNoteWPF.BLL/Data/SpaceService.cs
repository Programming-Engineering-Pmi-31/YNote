using System;
using System.Collections.Generic;
using YNoteWPF.DAL;
using YNoteWPF.DAL.Entities;
using System.Threading.Tasks;
using System.Data.Entity;
using YNoteWPF.BLL.Data.Interfaces;

namespace YNoteWPF.BLL.Data
{
    public class SpaceService : ISpaceService
    {
        private Func<YNoteDbContext> _contextCreator;

        public SpaceService(Func<YNoteDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<List<SpaceEntity>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Spaces.AsNoTracking().ToListAsync();
            }
        }

        public Task<SpaceEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
