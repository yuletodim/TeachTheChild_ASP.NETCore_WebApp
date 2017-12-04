namespace TeachTheChild.Data
{
    using System.Threading.Tasks;

    public interface IDbInitializer
    {
        Task Initialize();
    }
}
