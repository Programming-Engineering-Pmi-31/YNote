using System.Collections.Generic;
using System.Threading.Tasks;
using YNoteWPF.DAL.Entities;

namespace YNoteWPF.BLL.Data
{
    public interface INoteService
    {
        Task<List<NoteEntity>> GetAllAsync();

        Task<NoteEntity> GetByIdAsync(int id);
    }
}