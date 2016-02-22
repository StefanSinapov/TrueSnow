namespace TrueSnow.Web.Areas.Administration.ViewModels
{
    using TrueSnow.Data.Models;
    using TrueSnow.Web.Infrastructure.Mapping;

    public class AdminPostViewModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string CreatorId { get; set; }
    }
}