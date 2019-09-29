using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YNote.Entities;

namespace YNote.Configurations
{
    class TaskConfiguration : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Tasks");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.SumUp).IsRequired();

            builder.Property(e => e.SumUp).HasMaxLength(50);

            builder.Property(e => e.NoteId).IsRequired();

            builder.Property(e => e.Description).HasMaxLength(300);

            builder.Property(e => e.Status)
                .IsRequired()
                .HasDefaultValue(false);

            builder.HasOne(e => e.Note)
                .WithMany(note => note.Tasks)
                .HasForeignKey(e => e.NoteId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
