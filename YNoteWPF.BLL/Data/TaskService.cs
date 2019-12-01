using System;
using System.Collections.Generic;
using YNoteWPF.DAL;
using YNoteWPF.DAL.Entities;
using System.Threading.Tasks;
using System.Data.Entity;

namespace YNoteWPF.BLL.Data
{
    public class TaskService : ITaskService
    {
        private Func<YNoteDbContext> _contextCreator;

        public TaskService(Func<YNoteDbContext> contextCreator)
        {
            _contextCreator = contextCreator;
        }

        public async Task<List<TaskEntity>> GetAllAsync()
        {
            using (var ctx = _contextCreator())
            {
                return await ctx.Tasks.AsNoTracking().ToListAsync();
            }
        }

        public Task<TaskEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
