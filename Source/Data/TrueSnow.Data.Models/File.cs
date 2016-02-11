namespace TrueSnow.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Common.Models;

    public class File : BaseModel<int>
    {
        [StringLength(255)]
        public string FileName { get; set; }

        [StringLength(100)]
        public string ContentType { get; set; }

        public byte[] Content { get; set; }

        public FileType FileType { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
