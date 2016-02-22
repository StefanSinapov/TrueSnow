namespace TrueSnow.Services.Data.Contracts
{
    using System.Linq;

    using TrueSnow.Data.Models;

    public interface IArticlesService
    {
        IQueryable<Article> GetAll();

        Article GetById(string id);

        void Add(Article articleToAdd);

        void Save();

        void Delete(int id);
    }
}
