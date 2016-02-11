namespace TrueSnow.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class Post : BaseModel<int>
    {
        private ICollection<File> files;

        public Post()
        {
            this.files = new HashSet<File>();
        }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public virtual ICollection<File> Files
        {
            get { return this.files; }
            set { this.files = value; }
        }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }
    }
}
