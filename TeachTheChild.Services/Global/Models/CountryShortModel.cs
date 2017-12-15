namespace TeachTheChild.Services.Global.Models
{
    using TeachTheChild.Common.Mappings;
    using TeachTheChild.Data.Models;

    public class CountryShortModel : IMapFrom<Country>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
