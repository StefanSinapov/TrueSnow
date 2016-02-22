namespace TrueSnow.Web.Areas.Administration.ViewModels
{
    using Data.Models;
    using TrueSnow.Web.Infrastructure.Mapping;

    public class AdminCommentViewModel : IMapFrom<Comment>
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string CreatorId { get; set; }

        public int? EventId { get; set; }

        public int? PostId { get; set; }
    }
}