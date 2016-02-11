namespace TrueSnow.Services.Data.Contracts
{
    using System.Linq;

    using TrueSnow.Data.Models;

    public interface IPostsService
    {
        IQueryable<Post> GetAll();

        IQueryable<Post> GetByUserId(string id);

        void Add(Post postToAdd);
    }
}
