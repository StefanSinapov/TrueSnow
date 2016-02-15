namespace TrueSnow.Web.Models.Users
{
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ProfileViewModel : IMapFrom<User>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PostsCount { get; set; }

        public ICollection<File> Files { get; set; }

        public ICollection<User> Followers { get; set; }

        public ICollection<User> Following { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<User, ProfileViewModel>()
                .ForMember(x => x.PostsCount, opts => opts.MapFrom(x => x.Posts.Count));
        }
    }
}
