using System.Data.Entity.ModelConfiguration;
using YNoteWPF.DAL.Entities;

namespace YNoteWPF.DAL.Configurations
{
    class GroupConfiguration : EntityTypeConfiguration<GroupEntity>
    {
        public GroupConfiguration()
        {
            ToTable("Groups");

            HasKey(e => e.Id);

            Property(e => e.SpaceId).IsRequired();

            HasRequired(e => e.Space)
                .WithMany(space => space.Groups)
                .HasForeignKey(e => e.SpaceId)
                .WillCascadeOnDelete(true);
        }
    }
}
