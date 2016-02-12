namespace TrueSnow.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Comment : DbMigration
    {
        public override void Up()
        {
            this.CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        CreatorId = c.String(maxLength: 128),
                        CreatedOn = c.DateTime(nullable: false),
                        ModifiedOn = c.DateTime(),
                        IsDeleted = c.Boolean(nullable: false),
                        DeletedOn = c.DateTime(),
                        Post_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.CreatorId)
                .ForeignKey("dbo.Posts", t => t.Post_Id)
                .Index(t => t.CreatorId)
                .Index(t => t.IsDeleted)
                .Index(t => t.Post_Id);
        }

        public override void Down()
        {
            this.DropForeignKey("dbo.Comments", "Post_Id", "dbo.Posts");
            this.DropForeignKey("dbo.Comments", "CreatorId", "dbo.AspNetUsers");
            this.DropIndex("dbo.Comments", new[] { "Post_Id" });
            this.DropIndex("dbo.Comments", new[] { "IsDeleted" });
            this.DropIndex("dbo.Comments", new[] { "CreatorId" });
            this.DropTable("dbo.Comments");
        }
    }
}
