namespace TrueSnow.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Event : BaseModel<int>
    {
        private ICollection<User> attendants;

        public Event()
        {
            this.attendants = new HashSet<User>();
        }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<User> Attendants
        {
            get { return this.attendants; }
            set { this.attendants = value; }
        }
    }
}
