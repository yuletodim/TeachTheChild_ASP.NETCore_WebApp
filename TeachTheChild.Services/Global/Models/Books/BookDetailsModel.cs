namespace TeachTheChild.Services.Global.Models.Books
{
    using AutoMapper;
    using System.Collections.Generic;
    using System.Linq;
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models.Books;

    public class BookDetailsModel : IMapFrom<Book>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public string PictureUrl { get; set; }

        public List<BookCommentModel> Comments { get; set; } = new List<BookCommentModel>();

        public int Likes { get; set; }

        public int Dislikes { get; set; }

        public void ApplyCustomMappings(Profile profile)
        {
            profile.CreateMap<Book, BookDetailsModel>()
                .ForMember(a => a.Likes, opt => opt.MapFrom(a => a.Likes.Where(l => l.IsLike == true).Count()))
                .ForMember(a => a.Dislikes, opt => opt.MapFrom(a => a.Likes.Where(l => l.IsLike == false).Count()));
        }
    }
}
