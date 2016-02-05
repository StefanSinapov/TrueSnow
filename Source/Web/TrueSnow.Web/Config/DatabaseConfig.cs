namespace TrueSnow.Web.App_Start
{
    using System.Data.Entity;

    using TrueSnow.Data;
    using TrueSnow.Data.Migrations;

    public class DatabaseConfig
    {
        public static void Initialize()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TrueSnowDbContext, Configuration>());
            TrueSnowDbContext.Create().Database.Initialize(true);
        }
    }
}