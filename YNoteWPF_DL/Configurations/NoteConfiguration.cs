using System.Data.Entity.ModelConfiguration;
using YNoteWPF_DL.Entities;

namespace YNoteWPF_DL.Configurations
{
    class NoteConfiguration : EntityTypeConfiguration<NoteEntity>
    {
        public NoteConfiguration()
        {
            ToTable("Notes");

            HasKey(e => e.Id);

            Property(e => e.CreationTime).IsRequired();

            HasRequired(e => e.Space)
                .WithMany(space => space.Notes)
                .HasForeignKey(e => e.SpaceId)
                .WillCascadeOnDelete(false);

            HasRequired(e => e.Group)
                .WithMany(group => group.Notes)
                .HasForeignKey(e => e.GroupId)
                .WillCascadeOnDelete(true);

            HasRequired(e => e.AssignedUser)
                .WithMany(user => user.Notes)
                .HasForeignKey(e => e.AssignedUserId)
                .WillCascadeOnDelete(true);


        }
    }
}
