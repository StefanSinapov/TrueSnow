namespace TrueSnow.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using TrueSnow.Data.Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        public string Content { get; set; }

        public string CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public int? EventId { get; set; }

        public virtual Event Event { get; set; }

        public int? PostId { get; set; }

        public virtual Post Post { get; set; }
    }
}
