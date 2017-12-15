namespace TeachTheChild.Data.Models.Common
{
    public abstract class BaseLikeModel
    {
        public string UserId { get; set; }

        public User User { get; set; }

        public bool IsLike { get; set; }
    }
}

