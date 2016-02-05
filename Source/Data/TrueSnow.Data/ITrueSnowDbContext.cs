namespace TrueSnow.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Models;

    public interface ITrueSnowDbContext : IDisposable
    {
        int SaveChanges();

        IDbSet<User> Users { get; set; }

        IDbSet<Event> Events { get; set; }

        IDbSet<Post> Posts { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
