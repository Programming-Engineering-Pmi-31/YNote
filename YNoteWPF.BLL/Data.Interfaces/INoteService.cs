using System.Collections.Generic;
using System.Threading.Tasks;
using YNoteWPF.BLL.Data.Models;

namespace YNoteWPF.BLL.Data.Interfaces
{
    public interface INoteService
    {
        Task<List<NoteDTO>> GetAllNotesAsync();

        Task DeleteNoteAsync(int id);

        Task<NoteDTO> UpdateNoteAsync(UpdateNoteDTO updateNoteDTO);

        Task<NoteDTO> CreateNoteAsync(CreateNoteDTO createNoteDTO);
    }
}