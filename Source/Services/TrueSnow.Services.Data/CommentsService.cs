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
                .OrderBy(c => c.CreatedOn);
        }

        public IQueryable<Comment> GetByEventId(int id)
        {
            return this.comments
                .All()
                .Where(c => c.EventId == id)
                .OrderBy(c => c.CreatedOn);
        }

        public Comment GetById(int id)
        {
            return this.comments.GetById(id);
        }

        public IQueryable<Comment> GetByPostId(int id)
        {
            return this.comments
                .All()
                .Where(c => c.PostId == id)
                .OrderBy(c => c.CreatedOn);
        }

        public IQueryable<Comment> GetByUserId(string id)
        {
            return this.comments
                .All()
                .Where(c => c.CreatorId == id)
                .OrderBy(c => c.CreatedOn);
        }
    }
}
