namespace TrueSnow.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CommentUpdate : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Comments", name: "Post_Id", newName: "PostId");
            RenameIndex(table: "dbo.Comments", name: "IX_Post_Id", newName: "IX_PostId");
            AddColumn("dbo.Comments", "EventId", c => c.Int());
            AlterColumn("dbo.Events", "Description", c => c.String(nullable: false));
            AlterColumn("dbo.Files", "Content", c => c.Binary(nullable: false));
            AlterColumn("dbo.Comments", "Content", c => c.String(nullable: false));
            CreateIndex("dbo.Comments", "EventId");
            AddForeignKey("dbo.Comments", "EventId", "dbo.Events", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "EventId", "dbo.Events");
            DropIndex("dbo.Comments", new[] { "EventId" });
            AlterColumn("dbo.Comments", "Content", c => c.String());
            AlterColumn("dbo.Files", "Content", c => c.Binary());
            AlterColumn("dbo.Events", "Description", c => c.String());
            DropColumn("dbo.Comments", "EventId");
            RenameIndex(table: "dbo.Comments", name: "IX_PostId", newName: "IX_Post_Id");
            RenameColumn(table: "dbo.Comments", name: "PostId", newName: "Post_Id");
        }
    }
}
