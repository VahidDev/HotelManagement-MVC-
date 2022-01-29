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
            string path = PathGenerator.GenerateFullPath(folder, file.FileName, guid);
            using FileStream stream = new(path, FileMode.Create);
            await file.CopyToAsync(stream);
        }
    }
}
