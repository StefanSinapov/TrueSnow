namespace TrueSnow.Services.Data.Contracts
{
    using System.Linq;

    using TrueSnow.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetAll();

        IQueryable<Comment> GetByUserId(string id);

        IQueryable<Comment> GetByPostId(int id);

        IQueryable<Comment> GetByEventId(int id);

        Comment GetById(int id);

        void Add(Comment commentToAdd);
    }
}
