using System.Data.Entity.ModelConfiguration;
using YNoteWPF_DL.Entities;

namespace YNoteWPF_DL.Configurations
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
        }
    }
}
