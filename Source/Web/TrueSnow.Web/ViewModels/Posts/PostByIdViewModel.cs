using TrueSnow.Data.Models;

namespace TrueSnow.Web.Models.Posts
{
    public class PostByIdViewModel
    {
        public PostViewModel PostViewModel { get; set; }

        public bool PostLikedByCurrentUser { get; set; }
    }
}