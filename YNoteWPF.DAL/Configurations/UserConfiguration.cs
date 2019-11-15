using System.Data.Entity.ModelConfiguration;
using YNoteWPF.DAL.Entities;

namespace YNoteWPF.DAL.Configurations
{
    class UserConfiguration : EntityTypeConfiguration<UserEntity>
    {
        public UserConfiguration()
        {
            ToTable("Users");
                                                                       
            HasKey(e => e.Id);

            Property(e => e.Nickname).HasMaxLength(20).IsRequired();

            Property(e => e.Name).HasMaxLength(50).IsRequired();

            Property(e => e.Surname).HasMaxLength(50).IsRequired();

            Property(e => e.Password).HasMaxLength(16).IsRequired();

            Property(e => e.Email).HasMaxLength(30).IsRequired();

            HasMany<SpaceEntity>(u => u.SpacesAsUser)
                .WithMany(s => s.Users)
                .Map(su =>
                {
                    su.MapLeftKey("SpaceRefId");
                    su.MapRightKey("UserRefId");
                    su.ToTable("UserSpace");
                });

        }
    }
}
