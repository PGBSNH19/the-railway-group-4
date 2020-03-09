using System;
using System.IO;

namespace Train_Railway
{
    public class FileManager
    {
       public string passengers = @"Data/passengers.txt";

        public void ReadingFile(string filePath)
        {
            string[] data = File.ReadAllLines(filePath);
            foreach (var item in data)
            {
                Console.WriteLine(item);
            }
        }
    }
}