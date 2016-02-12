namespace TrueSnow.Services.Data
{
    using System.Linq;

    using Contracts;
    using TrueSnow.Data.Common;
    using TrueSnow.Data.Models;

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
                .OrderByDescending(p => p.CreatedOn);
        }

        public Post GetById(int id)
        {
            return this.posts
                .All()
                .FirstOrDefault(p => p.Id == id);
        }

        public IQueryable<Post> GetByUserId(string id)
        {
            return this.posts
                .All()
                .Where(p => p.CreatorId == id)
                .OrderByDescending(p => p.CreatedOn);
        }

        public void Add(Post postToAdd)
        {
            this.posts.Add(postToAdd);
            this.posts.Save();
        }
    }
}
