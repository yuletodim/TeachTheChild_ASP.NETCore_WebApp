namespace TeachTheChild.Services.Mappings
{
    using AutoMapper;

    public interface IHaveCustomMappings
    {
        void ApplyCustomMappings(Profile profile);
    }
}
