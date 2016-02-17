namespace TrueSnow.Services.Data.Contracts
{
    using System.Linq;

    using TrueSnow.Data.Models;

    public interface ILikesService
    {
        IQueryable<Like> GetByPostId(int id);

        Like GetByUserAndPostId(string userId, int postId);

        void Add(Like likeToAdd);

        void Remove(Like likeToRemove);
    }
}
