namespace TrueSnow.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    public sealed class Configuration : DbMigrationsConfiguration<TrueSnowDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(TrueSnowDbContext context)
        {
            if (!context.Roles.Any())
            {
                context.Roles.Add(new IdentityRole { Name = "Admin" });
                context.Roles.Add(new IdentityRole { Name = "User" });
                context.SaveChanges();
            }

            //if (!context.Files.Any())
            //{
            //    var defaultAvatar = new File
            //    {
            //        FileName = "default-avatar.png",
            //        FileType = FileType.Avatar,
            //        ContentType = "image/png",
            //        Content = 
            //    };
            //}
        }
    }
}
