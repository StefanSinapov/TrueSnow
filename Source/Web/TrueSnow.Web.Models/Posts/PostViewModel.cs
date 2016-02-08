namespace TrueSnow.Web.Models.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Data.Models;

    public class PostViewModel
    {
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<File> Files { get; set; }

        public User Creator { get; set; }
    }
}
