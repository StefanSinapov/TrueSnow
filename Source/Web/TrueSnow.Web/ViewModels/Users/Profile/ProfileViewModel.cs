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

        public File Avatar { get; set; }

        public File Cover { get; set; }

        public ICollection<User> Followers { get; set; }

        public ICollection<User> Following { get; set; }
    }
}
