namespace TeachTheChild.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using TeachTheChild.Web.Infrastructure.Constants;

    public static class TempDataDictionaryExtensions
    {
        //public static int TempDataSuccessMessageKey { get; private set; }

        //public static int TempDataErrorMessageKey { get; private set; }

        //public static int TempDataInfoMessageKey { get; private set; }

        public static void AddSuccessMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataSuccessMessageKey] = message;
        }

        public static void AddErrorMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataErrorMessageKey] = message;
        }

        public static void AddInfoMessage(this ITempDataDictionary tempData, string message)
        {
            tempData[WebConstants.TempDataInfoMessageKey] = message;
        }
    }
}
