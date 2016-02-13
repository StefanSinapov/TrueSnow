namespace TrueSnow.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class ScreenNameDelete : DbMigration
    {
        public override void Up()
        {
            this.DropColumn("dbo.AspNetUsers", "ScreenName");
        }

        public override void Down()
        {
            this.AddColumn("dbo.AspNetUsers", "ScreenName", c => c.String(nullable: false));
        }
    }
}
