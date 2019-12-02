using YNoteWPF.BLL.Data.Models;

namespace YNoteWPF.BLL.Data.Models
{
    public class TaskDTO
    {
        public int Id { get; set; }

        public NoteDTO Note { get; set; }

        public string SumUp { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
    }
}