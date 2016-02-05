namespace TrueSnow.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Post
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }
    }
}
