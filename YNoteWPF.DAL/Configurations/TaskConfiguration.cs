using System.Data.Entity.ModelConfiguration;
using YNoteWPF.DAL.Entities;

namespace YNoteWPF.DAL.Configurations
{
    class TaskConfiguration : EntityTypeConfiguration<TaskEntity>
    {
        public TaskConfiguration()
        {
            ToTable("Tasks");

            HasKey(e => e.Id);

            Property(e => e.SumUp).IsRequired();

            Property(e => e.SumUp).HasMaxLength(50);

            Property(e => e.NoteId).IsRequired();

            Property(e => e.Description).HasMaxLength(300);

            Property(e => e.Status).IsRequired();

            HasRequired(e => e.Note)
                .WithMany(note => note.Tasks)
                .HasForeignKey(e => e.NoteId)
                .WillCascadeOnDelete(false);
        }
    }
}
