namespace TrueSnow.Web.Models.Users
{
    using System.Collections.Generic;

    public class ProfileViewModel
    {
        public string Id { get; set; }

        public string ScreenName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Data.Models.File> Files { get; set; }
    }
}
