namespace TrueSnow.Web.Models.Events
{
    using System.Collections.Generic;

    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;
    using Services.Web.Contracts;

    public class EventViewModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public User Creator { get; set; }

        public File Photo { get; set; }

        public string Url
        {
            get
            {
                IIdentifierProvider identifier = new IdentifierProvider();
                return $"/Events/ById/{identifier.EncodeId(this.Id)}";
            }
        }

        public ICollection<User> Attendands { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
