namespace TeachTheChild.Web.Infrastructure.Constants
{
    public class WebConstants
    {
        public const string AppDomainName = "TeachTheChild";
        public const string AppEmail = "info.teach_the_child@gmail.com";
        public const string GmailHost = "smtp.gmail.com";

        // Areas
        public const string AdminArea = "Admin";
        public const string ModeratorArea = "Moderator";

        // Languages
        public const string DefaultEnglishCulture = "en";
        public const string BulgarianNeutralCulture = "bg";
        public const string SpanishNeutralCulture = "es";

        public const string TempDataSuccessMessageKey = "SuccessMessage";
        public const string TempDataErrorMessageKey = "ErrorMessage";

        // Success mesages
        public const string RegisterSuccess = "You registered succesfuly. Please confirm your registartion through the link in the email we just sent you.";
        public const string LoginSuccess = "You are logged in the system.";
        public const string LogoutSuccess = "You logged out the system.";
        public const string ProfileUpdateSuccess = "Your profile was updated.";
        public const string PasswordUpdateSuccess = "Your password has been changed.";

        // Error messages
        public const string ForgotPasswordError = "Recover password process failed.";
        public const string LoginError = "Log in failed. Check all form fields.";
        public const string ProfileUpdateError = "Failed to update profile.";

        // Tips
        public const string RegisterTips = "There's NO difficult child. It's hard to be a child in this world of tired, busy, impatient, hurrying people.";
        public const string LoginTips = "\"Our care of the child should be governed, not by the desire to make him learn things, but by the endeavor always to keep burning within him that light which is called intelligence.\" Maria Montessori";
        public const string ExternalLoginTips = "\"Children are human beings to whom respect is due, superior to us by reason of their innocence and of the greater possibilities of their future.\" Maria Montessori";
    }
}
