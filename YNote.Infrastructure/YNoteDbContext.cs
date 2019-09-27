using Microsoft.EntityFrameworkCore;
using YNote.Infrastructure.Configurations;
using YNote.Domain.Entities;

namespace YNote.Infrastructure
{
    public class YNoteDbContext:DbContext
    {
        public YNoteDbContext(DbContextOptions<YNoteDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<SpaceEntity> Spaces { get; set; }

        public DbSet<GroupEntity> Groups { get; set; }

        public DbSet<NoteEntity> Notes { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { optionsBuilder.UseSqlServer("Data Source=DESKTOP-8DEVSOF"); }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new SpaceConfiguration());

            modelBuilder.ApplyConfiguration(new GroupConfiguration());

            modelBuilder.ApplyConfiguration(new NoteConfiguration());

            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
