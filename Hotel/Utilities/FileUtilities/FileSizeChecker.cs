using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Hotel.Utilities.FileUtilities
{
    public static class FileSizeChecker
    {
        public static bool CheckSizeForMg(this IFormFile file)
        {
            if (file.Length >= 3 * 1000_000) return false;
            return true;
        }
    }
}
