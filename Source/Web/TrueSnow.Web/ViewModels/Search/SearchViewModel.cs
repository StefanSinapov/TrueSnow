namespace TrueSnow.Web.ViewModels.Search
{
    using System.Collections.Generic;

    using Models.Articles;
    using Models.Events;
    using Models.Users;

    public class SearchViewModel
    {
        public string Query { get; set; }

        public ICollection<ProfileViewModel> Users { get; set; }

        public ICollection<EventViewModel> Events { get; set; }

        public ICollection<ArticleViewModel> Articles { get; set; }
    }
}