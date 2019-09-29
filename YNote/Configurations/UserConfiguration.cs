using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using YNote.Entities;

namespace YNote.Configurations
{
    class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Nickname).HasMaxLength(20).IsRequired();

            builder.Property(e => e.Name).HasMaxLength(50).IsRequired();

            builder.Property(e => e.Surname).HasMaxLength(50).IsRequired();

            builder.Property(e => e.Password).HasMaxLength(16).IsRequired();

            builder.Property(e => e.Email).HasMaxLength(30).IsRequired();
        }
    }
}
