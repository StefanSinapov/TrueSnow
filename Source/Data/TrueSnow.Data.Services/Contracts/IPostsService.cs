namespace TrueSnow.Data.Services.Contracts
{
    using System.Linq;
    using TrueSnow.Data.Models;

    public interface IPostsService : IService
    {
        IQueryable<Post> GetAll();
    }
}
