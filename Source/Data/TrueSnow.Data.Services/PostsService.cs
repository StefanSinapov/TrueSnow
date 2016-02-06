namespace TrueSnow.Data.Services
{
    using System.Linq;
    using TrueSnow.Data.Models;
    using TrueSnow.Data.Repositories;
    using TrueSnow.Data.Services.Contracts;

    public class PostsService : IPostsService
    {
        private IRepository<Post> posts;

        public PostsService(IRepository<Post> posts)
        {
            this.posts = posts;
        }

        public IQueryable<Post> GetAll()
        {
            return this.posts
                .All()
                .OrderBy(p => p.CreatedOn);
        }
    }
}
