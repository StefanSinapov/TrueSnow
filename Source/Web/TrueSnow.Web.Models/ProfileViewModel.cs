using System.Collections.Generic;

namespace TrueSnow.Web.Models
{
    public class ProfileViewModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<Data.Models.File> Files { get; set; }
    }
}
