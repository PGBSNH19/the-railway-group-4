using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Railway
{
    class Program
    {
        static List<Timetable> timeTables = new List<Timetable>();
        static FilesPath m = new FilesPath();
        static void Main(string[] args)
        {
            IninitalizeData();

            
            
            Console.ReadKey();
        }

        static void IninitalizeData()
        {
            string[] tmp = new FileManager().ReadingFile(m.TimetablePath);
            for (int i = 1; i < tmp.Length; i++)
            {
                string[] tmp2 = tmp[i].Split(',');
                timeTables.Add(new Timetable(tmp2[3], tmp2[2], tmp2[0], int.Parse(tmp2[1])));
            }
        }
    }
}
