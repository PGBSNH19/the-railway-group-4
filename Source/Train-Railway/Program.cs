using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Railway
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager file = new FileManager();
            FilesPath m = new FilesPath();

            file.ReadingFile(m.PassengersPath);

            //var t = new Timetable().GetTrain();
            //Console.WriteLine(t);
        }
    }
}
