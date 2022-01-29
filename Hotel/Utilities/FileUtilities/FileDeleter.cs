using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hotel.Utilities.FileUtilities
{
    public static class FileDeleter
    {
        public static void Delete(string folder,string imageName)
        {
            string path = Path.Combine(folder, imageName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
    }
}
