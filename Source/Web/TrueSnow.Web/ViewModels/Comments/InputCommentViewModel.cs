namespace TrueSnow.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;

    public class InputCommentViewModel
    {
        [Required]
        public string Content { get; set; }

        public int PostId { get; set; }
    }
}