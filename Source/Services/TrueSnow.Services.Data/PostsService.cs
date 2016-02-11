namespace TrueSnow.Services.Data
{
    using System.Linq;

    using Contracts;
    using TrueSnow.Data.Models;
    using TrueSnow.Data.Common;

    public class PostsService : IPostsService
    {
        private readonly IDbRepository<Post> posts;

        public PostsService(IDbRepository<Post> posts)
        {
            this.posts = posts;
        }

        public IQueryable<Post> GetAll()
        {
            return this.posts
                .All()
                .OrderBy(p => p.CreatedOn);
        }

        public IQueryable<Post> GetByUserId(string id)
        {
            return this.posts
                .All()
                .Where(p => p.CreatorId == id)
                .OrderBy(p => p.CreatedOn);
        }

        public void Add(Post postToAdd)
        {
            this.posts.Add(postToAdd);
            this.posts.Save();
        }
    }
}
