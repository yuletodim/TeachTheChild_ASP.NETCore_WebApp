namespace TeachTheChild.Data.Models.Materials
{
    using TeachTheChild.Data.Models.Common;

    public abstract class Material : BaseModel
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public bool IsApproved { get; set; }
    }
}
