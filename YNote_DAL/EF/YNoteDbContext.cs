using System;
using Microsoft.EntityFrameworkCore;
using YNote_DAL.Configurations;
using YNote_DAL.Entities;

namespace YNote_DAL
{
    public class YNoteDbContext: DbContext
    {
        public YNoteDbContext(DbContextOptions<YNoteDbContext> options) : base(options) { }

        public DbSet<UserEntity> Users { get; set; }

        public DbSet<SpaceEntity> Spaces { get; set; }

        public DbSet<GroupEntity> Groups { get; set; }

        public DbSet<NoteEntity> Notes { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Seed seed = new Seed();
            seed.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new SpaceConfiguration());

            modelBuilder.ApplyConfiguration(new GroupConfiguration());

            modelBuilder.ApplyConfiguration(new NoteConfiguration());

            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
