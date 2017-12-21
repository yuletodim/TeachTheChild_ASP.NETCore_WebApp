namespace TeachTheChild.Services.Global.Models.Books
{
    using AutoMapper;
    using System;
    using System.Linq;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Books;

    public class BookCommentModel : IMapFrom<BookComment>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public DateTime CreatedOn { get; set; }

        public string User { get; set; }

        public string Content { get; set; }

        public int Answers { get; set; }

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public void ApplyCustomMappings(Profile profile)
        {
            profile.CreateMap<BookComment, BookCommentModel>()
                .ForMember(ac => ac.User, opt => opt.MapFrom(ac => ac.User.Name))
                .ForMember(ac => ac.Answers, opt => opt.MapFrom(ac => ac.Answers.Count))
                .ForMember(ac => ac.Likes, opt => opt.MapFrom(ac => ac.Likes.Where(l => l.IsLike == true).Count()))
                .ForMember(ac => ac.Dislikes, opt => opt.MapFrom(ac => ac.Likes.Where(l => l.IsLike == false).Count()));
        }
    }
}
