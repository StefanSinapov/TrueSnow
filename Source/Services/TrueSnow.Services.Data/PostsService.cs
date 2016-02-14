namespace TrueSnow.Services.Data
{
    using System.Linq;

    using Contracts;
    using TrueSnow.Data.Common;
    using TrueSnow.Data.Models;
    using Web.Contracts;

    public class PostsService : IPostsService
    {
        private readonly IDbRepository<Post> posts;
        private readonly IIdentifierProvider identifierProvider;

        public PostsService(IDbRepository<Post> posts, IIdentifierProvider identifierProvider)
        {
            this.posts = posts;
            this.identifierProvider = identifierProvider;
        }

        public IQueryable<Post> GetAll()
        {
            return this.posts
                .All()
                .OrderByDescending(p => p.CreatedOn);
        }

        public Post GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            return this.posts.GetById(intId);
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
