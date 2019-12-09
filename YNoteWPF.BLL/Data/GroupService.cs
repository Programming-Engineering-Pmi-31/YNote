using System;
using System.Collections.Generic;
using YNoteWPF.DAL;
using YNoteWPF.DAL.Entities;
using YNoteWPF.BLL.Data.Interfaces;
using System.Threading.Tasks;
using System.Data.Entity;
using YNoteWPF.BLL.Data.Models;

namespace YNoteWPF.BLL.Data
{
    public class GroupService : IGroupService
    {
        private Func<YNoteDbContext> _contextCreator;

        public GroupService(Func<YNoteDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<List<GroupDTO>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                throw new NotImplementedException();
                //return await ctx.Groups.AsNoTracking().ToListAsync();
            }
        }

        public Task<GroupDTO> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
