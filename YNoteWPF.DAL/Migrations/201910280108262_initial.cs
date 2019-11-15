namespace YNoteWPF.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        SpaceId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spaces", t => t.SpaceId, cascadeDelete: true)
                .Index(t => t.SpaceId);
            
            CreateTable(
                "dbo.Notes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GroupId = c.Int(nullable: false),
                        SpaceId = c.Int(nullable: false),
                        CreationTime = c.DateTimeOffset(nullable: false, precision: 7),
                        AssignedUserId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AssignedUserId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.Spaces", t => t.SpaceId)
                .Index(t => t.GroupId)
                .Index(t => t.SpaceId)
                .Index(t => t.AssignedUserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false, maxLength: 50),
                        Surname = c.String(nullable: false, maxLength: 50),
                        Nickname = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 30),
                        Password = c.String(nullable: false, maxLength: 16),
                        SpaceEntity_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Spaces", t => t.SpaceEntity_Id)
                .Index(t => t.SpaceEntity_Id);
            
            CreateTable(
                "dbo.Spaces",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SpaceName = c.String(nullable: false, maxLength: 100),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Tasks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NoteId = c.Int(nullable: false),
                        SumUp = c.String(nullable: false, maxLength: 50),
                        Description = c.String(maxLength: 300),
                        Status = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notes", t => t.NoteId)
                .Index(t => t.NoteId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "SpaceId", "dbo.Spaces");
            DropForeignKey("dbo.Tasks", "NoteId", "dbo.Notes");
            DropForeignKey("dbo.Notes", "SpaceId", "dbo.Spaces");
            DropForeignKey("dbo.Notes", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.Notes", "AssignedUserId", "dbo.Users");
            DropForeignKey("dbo.Users", "SpaceEntity_Id", "dbo.Spaces");
            DropForeignKey("dbo.Spaces", "AuthorId", "dbo.Users");
            DropIndex("dbo.Tasks", new[] { "NoteId" });
            DropIndex("dbo.Spaces", new[] { "AuthorId" });
            DropIndex("dbo.Users", new[] { "SpaceEntity_Id" });
            DropIndex("dbo.Notes", new[] { "AssignedUserId" });
            DropIndex("dbo.Notes", new[] { "SpaceId" });
            DropIndex("dbo.Notes", new[] { "GroupId" });
            DropIndex("dbo.Groups", new[] { "SpaceId" });
            DropTable("dbo.Tasks");
            DropTable("dbo.Spaces");
            DropTable("dbo.Users");
            DropTable("dbo.Notes");
            DropTable("dbo.Groups");
        }
    }
}
