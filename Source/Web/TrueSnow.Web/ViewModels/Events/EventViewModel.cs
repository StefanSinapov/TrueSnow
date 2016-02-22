namespace TrueSnow.Web.Models.Events
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Data.Models;
    using Ganss.XSS;
    using Infrastructure;
    using Infrastructure.Mapping;
    using Services.Web;
    using Services.Web.Contracts;

    public class EventViewModel : IMapFrom<Event>
    {
        private ISanitizer sanitizer;

        public EventViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        [AllowHtml]
        public string Description { get; set; }

        public string DescriptionSanitized
        {
            get
            {
                return this.sanitizer.Sanitize(this.Description);
            }
        }

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
