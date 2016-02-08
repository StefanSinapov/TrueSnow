namespace TrueSnow.Web.Models
{
    using System.Collections.Generic;
    using TrueSnow.Data.Models;

    public class BaseViewModel
    {
        public string ScreenName { get; set; }

        public ICollection<File> Files { get; set; }
    }
}
