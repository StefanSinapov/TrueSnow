namespace TrueSnow.Data
{
    using System.Data.Entity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Models;

    public class TrueSnowDbContext : IdentityDbContext<User>, ITrueSnowDbContext
    {
        public TrueSnowDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public IDbSet<Event> Events { get; set; }

        public IDbSet<Post> Posts { get; set; }

        public static TrueSnowDbContext Create()
        {
            return new TrueSnowDbContext();
        }
    }
}