namespace TrueSnow.Services.Data.Contracts
{
    using System.Linq;

    using TrueSnow.Data.Models;

    public interface IPostsService
    {
        IQueryable<Post> GetAll();

        Post GetById(string id);

        IQueryable<Post> GetByUserId(string id);

        void Add(Post postToAdd);
    }
}
