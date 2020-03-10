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
            List<Timetable> timeTables = new List<Timetable>();
            //timeTables.Add(new Timetable("1", "1", "1", 1));

            //FileManager file = new FileManager();
            FilesPath m = new FilesPath();

            //file.ReadingFile(m.PassengersPath);
            Timetable tt = new Timetable("hello", "hello", "1", 1);
            

            string[] tmp = new FileManager().ReadingFile(m.TimetablePath);
            for(int i = 1; i < tmp.Length; i++)
            {
                string[] tmp2 = tmp[i].Split(',');
                timeTables.Add(new Timetable(tmp2[3], tmp2[2], tmp2[0], int.Parse(tmp2[1])));    
            }


            //var t = new Timetable().GetTrain();
            //Console.WriteLine(t);

            Console.ReadKey();
        }
    }
}
