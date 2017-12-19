namespace TeachTheChild.Services.Moderator.Contracts
{
    using System.Collections.Generic;
    using TeachTheChild.Services.Moderator.Models;

    public interface IBooksModeratorService
    {
        IEnumerable<BookTableModeratorModel> GetFilteredPortion(
            int length,
            int start,
            string sortCol,
            string sortDir,
            string search,
            out int count);
    }
}
