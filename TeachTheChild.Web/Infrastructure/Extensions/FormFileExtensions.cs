namespace TeachTheChild.Web.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Http;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TeachTheChild.Web.Infrastructure.Constants;

    public static class FormFileExtensions
    {
        public static async Task<string> SaveToFileSystem(this IFormFile formFile, string rootPath, string childFolder, string fileName = null)
        {
            if (fileName == null)
            {
                var fileExtension = formFile.FileName.Substring(formFile.FileName.LastIndexOf('.'));
                fileName = $"{WebConstants.FilesFolder}{childFolder}/{Guid.NewGuid().ToString()}{fileExtension}";
            }
       
            var path = $"{rootPath}{fileName}";

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await formFile.CopyToAsync(fileStream);
            }

            return fileName;
        }
    }
}
