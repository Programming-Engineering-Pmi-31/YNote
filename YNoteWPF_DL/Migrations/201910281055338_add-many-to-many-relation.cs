namespace YNoteWPF_DL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addmanytomanyrelation : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Users", "SpaceEntity_Id", "dbo.Spaces");
            DropIndex("dbo.Users", new[] { "SpaceEntity_Id" });
            CreateTable(
                "dbo.UserSpace",
                c => new
                    {
                        SpaceRefId = c.Guid(nullable: false),
                        UserRefId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SpaceRefId, t.UserRefId })
                .ForeignKey("dbo.Users", t => t.SpaceRefId, cascadeDelete: true)
                .ForeignKey("dbo.Spaces", t => t.UserRefId, cascadeDelete: true)
                .Index(t => t.SpaceRefId)
                .Index(t => t.UserRefId);
            
            DropColumn("dbo.Users", "SpaceEntity_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "SpaceEntity_Id", c => c.Int());
            DropForeignKey("dbo.UserSpace", "UserRefId", "dbo.Spaces");
            DropForeignKey("dbo.UserSpace", "SpaceRefId", "dbo.Users");
            DropIndex("dbo.UserSpace", new[] { "UserRefId" });
            DropIndex("dbo.UserSpace", new[] { "SpaceRefId" });
            DropTable("dbo.UserSpace");
            CreateIndex("dbo.Users", "SpaceEntity_Id");
            AddForeignKey("dbo.Users", "SpaceEntity_Id", "dbo.Spaces", "Id");
        }
    }
}
