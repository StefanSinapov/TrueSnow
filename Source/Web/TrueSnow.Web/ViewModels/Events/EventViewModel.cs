namespace TrueSnow.Web.Models.Events
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class EventViewModel : IMapFrom<Event>
    {
        public string Title { get; set; }

        public string Description { get; set; }
    }
}
