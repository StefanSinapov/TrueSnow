namespace TrueSnow.Web.Models.Users
{
    using System.Collections.Generic;

    using Data.Models;
    using Infrastructure.Mapping;

    public class ProfileViewModel : IMapFrom<User>
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<File> Files { get; set; }
    }
}
