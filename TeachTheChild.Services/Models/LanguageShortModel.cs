namespace TeachTheChild.Services.Models
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models;

    public class LanguageShortModel : IMapFrom<Language>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
