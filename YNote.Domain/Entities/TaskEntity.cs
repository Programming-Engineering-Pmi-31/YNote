using System;
using YNote.Domain.Entities.Base;

namespace YNote.Domain.Entities {
    public class TaskEntity:BaseEntity {
        public int NoteId { get; set; }
        public string SumUp { get; set; }
        public string Description { get; set; }
        public bool Done { get; set; }
    }
}
