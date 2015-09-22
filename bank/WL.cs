using System;
using System.IO;

namespace bank
{
    class WL
    {
        public static string[] itemsTarget(string path)
        {
            var dir = new DirectoryInfo(path);
            FileInfo[] files = dir.GetFiles("*.dbf");
            string[] filesPath = new string[files.Length];
            for(int i=0;i<files.Length;i++)
            {
                filesPath[i] = files[i].FullName;
            }
            return filesPath;
        }        
    }
}
