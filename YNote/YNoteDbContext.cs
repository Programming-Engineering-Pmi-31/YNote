using System;
using Microsoft.EntityFrameworkCore;
using YNote.Configurations;
using YNote.Entities;

namespace YNote
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

            modelBuilder.Entity<UserEntity>().HasData(new UserEntity
            {
                Id = new Guid("30FB2DD3-EA0E-4F05-B0DB-EF6341A593F0"),
                Name = "Andriy",
                Surname = "Burtso",
                Nickname = "Shails",
                Email = "burtso.ab@gmail.com",
                Password = "SomePassword"
            });

            modelBuilder.Entity<SpaceEntity>().HasData(new SpaceEntity
            {
                Id = 1,
                SpaceName = "FirstSpace",
                AuthorId = new Guid("30FB2DD3-EA0E-4F05-B0DB-EF6341A593F0")
            });

            modelBuilder.Entity<GroupEntity>().HasData(new GroupEntity
            {
                Id = 1,
                GroupName = "FirstGroup",
                SpaceId = 1
            });

            modelBuilder.Entity<NoteEntity>().HasData(new NoteEntity
            {
                Id = 1,
                GroupId = 1,
                AssignedUserId = new Guid("30FB2DD3-EA0E-4F05-B0DB-EF6341A593F0")
            });

            modelBuilder.Entity<TaskEntity>().HasData(new TaskEntity
            {
                Id = 1,
                NoteId = 1,
                SumUp = "Text",
                Description = "A lot of text",
            });

            modelBuilder.ApplyConfiguration(new UserConfiguration());

            modelBuilder.ApplyConfiguration(new SpaceConfiguration());

            modelBuilder.ApplyConfiguration(new GroupConfiguration());

            modelBuilder.ApplyConfiguration(new NoteConfiguration());

            modelBuilder.ApplyConfiguration(new TaskConfiguration());
        }
    }
}
