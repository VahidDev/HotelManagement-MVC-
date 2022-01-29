using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hotel.Utilities.FileUtilities
{
    public static class FileContentChecker
    {
        public static bool CheckContentForImg(this IFormFile file)
        {
            if (!file.ContentType.Contains("image")) return false;
            return true;
        }
    }
}
