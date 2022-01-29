using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hotel.Utilities.FileUtilities
{
    public static class FileCreator
    {
        public async static Task CreateAsync(this IFormFile file,Guid guid,string folder)
        {
            string path = Path.Combine(folder, guid+file.FileName);
            using FileStream stream = new(path, FileMode.Create);
            await file.CopyToAsync(stream);
        }
    }
}
