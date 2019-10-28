using System.Data.Entity.ModelConfiguration;
using YNoteWPF_DL.Entities;

namespace YNoteWPF_DL.Configurations
{
    class SpaceConfiguration : EntityTypeConfiguration<SpaceEntity>
    {
        public SpaceConfiguration()
        {
            ToTable("Spaces");

            HasKey(e => e.Id);

            Property(e => e.SpaceName).IsRequired();

            Property(e => e.SpaceName).HasMaxLength(100);

            HasRequired(e => e.Author)
                .WithMany(author => author.SpacesAsAuthor)
                .HasForeignKey(e => e.AuthorId)
                .WillCascadeOnDelete(false);
        }
    }
}
