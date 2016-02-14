namespace TrueSnow.Web.Models.Events
{
    using System.Collections.Generic;

    using Data.Models;
    using Infrastructure.Mapping;

    public class EventViewModel : IMapFrom<Event>
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public User Creator { get; set; }

        public ICollection<User> Attendands { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
