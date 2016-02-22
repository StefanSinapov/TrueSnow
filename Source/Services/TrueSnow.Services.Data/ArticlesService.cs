namespace TrueSnow.Services.Data
{
    using System.Linq;

    using TrueSnow.Data.Common;
    using TrueSnow.Data.Models;
    using TrueSnow.Services.Data.Contracts;
    using Web.Contracts;

    public class ArticlesService : IArticlesService
    {
        private readonly IDbRepository<Article> articles;
        private readonly IIdentifierProvider identifierProvider;

        public ArticlesService(IDbRepository<Article> articles, IIdentifierProvider identifierProvider)
        {
            this.articles = articles;
            this.identifierProvider = identifierProvider;
        }

        public void Add(Article articleToAdd)
        {
            this.articles.Add(articleToAdd);
            this.articles.Save();
        }

        public IQueryable<Article> GetAll()
        {
            return this.articles
                .All()
                .OrderByDescending(p => p.CreatedOn);
        }

        public Article GetById(string id)
        {
            var intId = this.identifierProvider.DecodeId(id);
            return this.articles.GetById(intId);
        }

        public void Save()
        {
            this.articles.Save();
        }

        public void Delete(int id)
        {
            var articleToDelete = this.articles.All().FirstOrDefault(x => x.Id == id);
            this.articles.Delete(articleToDelete);
            this.articles.Save();
        }
    }
}
