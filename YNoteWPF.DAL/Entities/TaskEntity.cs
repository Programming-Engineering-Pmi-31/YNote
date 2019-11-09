using YNoteWPF.DAL.Entities.Base;

namespace YNoteWPF.DAL.Entities {
    public class TaskEntity:BaseEntity {

        public int NoteId { get; set; }
        public NoteEntity Note { get; set; }

        public string SumUp { get; set; }

        public string Description { get; set; }

        public bool Status { get; set; }
    }
}
