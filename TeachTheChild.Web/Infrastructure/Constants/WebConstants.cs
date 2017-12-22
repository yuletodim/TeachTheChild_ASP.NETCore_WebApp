namespace TeachTheChild.Web.Infrastructure.Constants
{
    public class WebConstants
    {
        public const string AppDomainName = "TeachTheChild";
        public const string AppEmail = "info.teach_the_child@gmail.com";
        public const string GmailHost = "smtp.gmail.com";

        public const string JpgMimeType = "image/jpeg";
        public const string PngMimeType = "image/png";
        public const string GifMimeType = "image/gif";
        public const string ImageType = "image/*";
        public const string Mp4MimeType = "video/mp4";

        public const string StaicFilesFolder = "wwwroot";
        public const string FilesFolder = "/Files";
        public const string DownloadsFolder = "/Downloads";
        public const string BooksFolder = "/Books";
        public const string VideosFolder = "/Videos";

        public const int MaxPictureLength = 2 * 1024 * 1024;
        public const int DownloadsPageSize = 6;
        public const int BooksPageSize = 6;
        public const int ArticlesPageSize = 2;
        public const int VideosPageSize = 5;

        // Areas
        public const string AdminArea = "Admin";
        public const string ModeratorArea = "Moderator";

        // Languages
        public const string DefaultEnglishCulture = "en";
        public const string BulgarianNeutralCulture = "bg";
        public const string SpanishNeutralCulture = "es";

        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const string TempDataErrorMessageKey = "ErrorMessage";
        public const string TempDataInfoMessageKey = "InfoMessage";

        // Success mesages
        public const string RegisterSuccess = "You registered succesfuly. Please confirm your registartion through the link in the email we just sent you.";
        public const string LoginSuccess = "You are logged in the system.";
        public const string LogoutSuccess = "You logged out the system.";
        public const string ProfileUpdateSuccess = "Your profile was updated.";
        public const string PasswordUpdateSuccess = "Your password has been changed.";
        public const string SaveBookSuccess = "New book added.";
        public const string SaveDownloadsSuccess = "New material added.";
        public const string PublishArticleSuccess = "Article saved.";

        // Error messages
        public const string ForgotPasswordError = "Recover password process failed.";
        public const string LoginError = "Log in failed. Check all form fields.";
        public const string ProfileUpdateError = "Failed to update profile.";
        public const string PublishArticleError = "Failed to save article.";
        public const string SaveBookError = "Failed to save book.";
        public const string SaveDownloadsError = "Failed to save material.";
        public const string NotSupportedFile = "Not supported file format";
        public const string DeleteDownloadPictureEror = "Could not delte picture.";

        // Info messages
        public const string UserNoPermissionsEdit = "Only author can edit their materials.";

        // Tips
        public const string RegisterTips = "There's NO difficult child. It's hard to be a child in this world of tired, busy, impatient, hurrying people.";
        public const string LoginTips = "\"Our care of the child should be governed, not by the desire to make him learn things, but by the endeavor always to keep burning within him that light which is called intelligence.\" Maria Montessori";
        public const string ExternalLoginTips = "\"Children are human beings to whom respect is due, superior to us by reason of their innocence and of the greater possibilities of their future.\" Maria Montessori";
        public const string CreateArticleTip = "\"Imagination does not become great until human beings, given the courage and the strength, use it to create.\" Maria Montessori";
        public const string ViewArticleTip = "\"It is not enough for the teacher to love the child. She must first love and understand the universe. She must prepare herself, and truly work at it.\" Maria Montessori";
        public const string CreateDownloadsTip = "\"The environment must be rich in motives which lend interest to activity and invite the child to conduct his own experiences. .\" Maria Montessori";
        public const string ViewDownloadsTip = "\"The first essential for the child’s development is concentration. The child who concentrates is immensely happy.\" Maria Montessori";
        public const string AddBookTip = "\"It is true that we cannot make a genius. We can only give to teach child the chance to fulfil his potential possibilities.\"  Maria Montessori";
        public const string AddVideoTip = "\"Respect all the reasonable forms of activity in which the child engages and try to understand them.\"          Maria Montessori";
        public const string IndexTip = "It is no easy to code while you are doing lego with your 6 years old :) Yulia ";
    }
}
