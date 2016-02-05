namespace TrueSnow.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Event
    {
        private ICollection<User> attendants;

        public Event()
        {
            this.attendants = new HashSet<User>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<User> Attendants
        {
            get { return this.attendants; }
            set { this.attendants = value; }
        }
    }
}
