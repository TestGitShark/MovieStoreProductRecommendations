using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MovieStore
{
    public class FileReader
    {
            //private string rootPath;

            //public FileReader(string rootFilePath)
            //{
            //    rootPath = rootFilePath;
            //}
        public static List<string> GetLinesFromFile(string filePath)
        {
            return (File.ReadAllLines(filePath).ToList());
        }
    }
}
