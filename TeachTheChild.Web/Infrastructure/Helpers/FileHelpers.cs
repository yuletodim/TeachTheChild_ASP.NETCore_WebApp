namespace TeachTheChild.Web.Infrastructure.Helpers
{
    using System.IO;

    public static class FileHelpers
    {
        public static bool Delete(string path)
        {
            if (!File.Exists(path))
            {
                return false;
            }

            File.Delete(path);

            return true;
        }
    }
}
