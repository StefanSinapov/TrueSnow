namespace TrueSnow.Services.Data
{
    using System.Collections.Generic;
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
            //this.identifierProvider = identifierProvider;
        }

        public IQueryable<Post> GetAll()
        {
            return this.posts
                .All()
                .OrderByDescending(p => p.CreatedOn);
        }

        public Post GetById(int id)
        {
            //var intId = this.identifierProvider.DecodeId(id);
            return this.posts.GetById(id);
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

        public IQueryable<Post> GetFollowingPostsByUserFollowing(ICollection<User> userFollowing)
        {
            List<Post> followingPosts = new List<Post>();
            foreach (User followingUser in userFollowing)
            {
                var currentFollowingUserPosts = this.GetByUserId(followingUser.Id);
                foreach (var post in currentFollowingUserPosts)
                {
                    followingPosts.Add(post);
                }
            }

            return followingPosts.AsQueryable().OrderByDescending(x => x.CreatedOn);
        }
    }
}
