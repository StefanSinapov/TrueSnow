namespace TrueSnow.Services.Data
{
    using System.Linq;

    using TrueSnow.Data.Common;
    using TrueSnow.Data.Models;
    using TrueSnow.Services.Data.Contracts;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;

        public CommentsService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public void Add(Comment commentToAdd)
        {
            this.comments.Add(commentToAdd);
            this.comments.Save();
        }

        public IQueryable<Comment> GetAll()
        {
            return this.comments
                .All()
                .OrderByDescending(c => c.CreatedOn);
        }

        public IQueryable<Comment> GetByEventId(int id)
        {
            return this.comments
                .All()
                .Where(c => c.EventId == id)
                .OrderByDescending(c => c.CreatedOn);
        }

        public Comment GetById(int id)
        {
            return this.comments
                .All()
                .FirstOrDefault(c => c.Id == id);
        }

        public IQueryable<Comment> GetByPostId(int id)
        {
            return this.comments
                .All()
                .Where(c => c.PostId == id)
                .OrderByDescending(c => c.CreatedOn);
        }

        public IQueryable<Comment> GetByUserId(string id)
        {
            return this.comments
                .All()
                .Where(c => c.CreatorId == id)
                .OrderByDescending(c => c.CreatedOn);
        }
    }
}
