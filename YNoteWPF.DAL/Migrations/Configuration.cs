namespace YNoteWPF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using YNoteWPF.DAL.Entities;

    internal sealed class Configuration : DbMigrationsConfiguration<YNoteWPF.DAL.YNoteDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }
                                                 
        protected override void Seed(YNoteWPF.DAL.YNoteDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //You can use the DbSet<T>.AddOrUpdate() helper extension method
            //to avoid creating duplicate seed data.

          context.Users.AddOrUpdate(
              e => e.Id, new UserEntity
              {
                  Id = new Guid("30FB2DD3-EA0E-4F05-B0DB-EF6341A593F0"),
                  Name = "Andriy",
                  Surname = "Burtso",
                  Nickname = "Shails",
                  Email = "burtso.ab@gmail.com",
                  Password = "SomePassword"
              });

            context.Spaces.AddOrUpdate(
                e => e.Id, new SpaceEntity
                {
                    Id = 1,
                    SpaceName = "FirstSpace",
                    AuthorId = new Guid("30FB2DD3-EA0E-4F05-B0DB-EF6341A593F0")
                });

            context.Groups.AddOrUpdate(
                e => e.Id, new GroupEntity
                {
                    Id = 1,
                    GroupName = "FirstGroup",
                    SpaceId = 1
                });

            context.Notes.AddOrUpdate(
                e => e.Id, new NoteEntity
                {
                    Id = 1,
                    GroupId = 1,
                    SpaceId = 1,
                    AssignedUserId = new Guid("30FB2DD3-EA0E-4F05-B0DB-EF6341A593F0")
                });

            context.Tasks.AddOrUpdate(
                e => e.Id, new TaskEntity
                {
                    Id = 1,
                    NoteId = 1,
                    SumUp = "Text",
                    Description = "A lot of text",
                });
        }
    }
}
