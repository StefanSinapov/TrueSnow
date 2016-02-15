namespace TrueSnow.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Event : BaseModel<int>
    {
        private ICollection<User> attendants;
        private ICollection<Comment> comments;

        public Event()
        {
            this.attendants = new HashSet<User>();
            this.comments = new HashSet<Comment>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public int PhotoId { get; set; }

        public virtual File Photo { get; set; }

        public virtual ICollection<User> Attendants
        {
            get { return this.attendants; }
            set { this.attendants = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
