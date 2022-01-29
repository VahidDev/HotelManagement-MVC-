using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Hotel.Utilities.FileUtilities
{
    public static class PathGenerator
    {
        public static string GenerateFullPath(string folder,string fileName,Guid guid)
        {
            return Path.Combine(folder, guid + fileName);
        }
    }
}
