namespace TrueSnow.Web.Models.Posts
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;

    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Web;
    using Services.Web.Contracts;

    public class PostViewModel : IMapFrom<Post>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Title { get; set; }

        [Required]
        [MinLength(5)]
        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public File Photo { get; set; }

        public User Creator { get; set; }

        public int CommentsCount { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public int Likes { get; set; }

        //public string Url
        //{
        //    get
        //    {
        //        IIdentifierProvider identifier = new IdentifierProvider();
        //        return $"/Post/{identifier.EncodeId(this.Id)}";
        //    }
        //}

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Post, PostViewModel>()
                .ForMember(x => x.CommentsCount, opts => opts.MapFrom(x => x.Comments.Count))
                .ForMember(x => x.Likes, opts => opts.MapFrom(x => x.Likes.Where(l => !l.IsDeleted).Count()));
        }
    }
}
