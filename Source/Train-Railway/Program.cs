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
        static List<Passenger> passengers = new List<Passenger>();
        static List<Station> stations = new List<Station>();
        static List<Train> trains = new List<Train>();
        //tracks list here

        static FilesPath m = new FilesPath();
        static void Main(string[] args)
        {
            IninitalizeData();

                       
            Console.ReadKey();
        }

        static void IninitalizeData()
        {
            InitializeTimeTable();
            InitializePassengers();
            InitializeTrains();
            InitializeStations();
            //InitializeTracks();
        }

        static void InitializeTimeTable()
        {
            string[] tmp = new FileManager().ReadingFile(m.TimetablePath);
            for (int i = 1; i < tmp.Length; i++)
            {
                string[] tmp2 = tmp[i].Split(',');
                timeTables.Add(new Timetable(tmp2[3], tmp2[2], tmp2[0], int.Parse(tmp2[1])));
            }
        }

        static void InitializePassengers()
        {
            string[] tmp = new FileManager().ReadingFile(m.PassengersPath);
            for (int i = 1; i < tmp.Length; i++)
            {
                string[] tmp2 = tmp[i].Split(',');
                passengers.Add(new Passenger());
            }
        }

        static void InitializeTrains()
        {
            string[] tmp = new FileManager().ReadingFile(m.TimetablePath);
            for (int i = 1; i < tmp.Length; i++)
            {
                string[] tmp2 = tmp[i].Split(',');
                timeTables.Add(new Timetable(tmp2[3], tmp2[2], tmp2[0], int.Parse(tmp2[1])));
            }
        }

        static void InitializeStations()
        {
            string[] tmp = new FileManager().ReadingFile(m.TimetablePath);
            for (int i = 1; i < tmp.Length; i++)
            {
                string[] tmp2 = tmp[i].Split(',');
                timeTables.Add(new Timetable(tmp2[3], tmp2[2], tmp2[0], int.Parse(tmp2[1])));
            }
        }

        static void InitializeTracks() { }
    }
}
