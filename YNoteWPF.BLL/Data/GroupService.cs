using System;
using System.Collections.Generic;
using YNoteWPF.DAL;
using YNoteWPF.DAL.Entities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace YNoteWPF.BLL.Data
{
    public class GroupService : IGroupService
    {
        private Func<YNoteDbContext> _contextCreator;

        public GroupService(Func<YNoteDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<List<GroupEntity>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Groups.AsNoTracking().ToListAsync();
            }
        }

        public Task<GroupEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
