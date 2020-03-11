using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;


namespace Train_Railway
{
    class Program
    {
        static List<Timetable> timeTables = new List<Timetable>();
        static List<Passenger> passengers = new List<Passenger>();
        static List<Station> stations = new List<Station>();
        static List<Train> trains = new List<Train>();
        static List<Track> tracks = new List<Track>();

        static FilesPath m = new FilesPath();
        static Clock clock = new Clock(10,00);
        static void Main(string[] args)
        {
            IninitalizeData();
            Thread train1 = new Thread(StartTrain);
            train1.Start();
            TIme();
            ShowTime();

            Console.ReadKey();
        }

        static async void TIme()
        {
            while (true)
            {
                clock.Tick();
                //Console.WriteLine(clock.DisplayTime());
                await Task.Delay(1000);
                //Console.Clear();
            }
        }
        static void IninitalizeData()
        {
            InitializeTimeTable();
            InitializePassengers();
            InitializeTrains();
            InitializeStations();
            InitializeTracks();
        }

        static void InitializeTimeTable()
        {
            string[] tmp = FileManager.ReadFile(m.TimetablePath);
            FileManager.SplitFile(tmp, timeTables);
            
            Console.WriteLine("TIMETABLE");
            foreach(var t in timeTables)
            {
                Console.WriteLine($"{t.Arrival} {t.Departure} {t.StationID} {t.TrainID}");
            }
        }

        static void InitializePassengers()
        {
            string[] tmp = FileManager.ReadFile(m.PassengersPath);
            FileManager.SplitFile(tmp, passengers);

            Console.WriteLine("\n\rPASSENGERS");
            foreach (var t in passengers)
            {
                Console.WriteLine($"{t.ID} {t.Name}");
            }
        }
        
        static void InitializeTrains()
        {
            string[] tmp = FileManager.ReadFile(m.TrainPath);
            FileManager.SplitFile(tmp, trains);

            Console.WriteLine("\n\rTRAINS");
            foreach (var t in trains)
            {
                Console.WriteLine($"{t.ID} {t.Name} {t.MaxSpeed} {t.Operated}");
            }
        }

        static void InitializeStations()
        {
            string[] tmp = FileManager.ReadFile(m.StationPath);
            FileManager.SplitFile(tmp, stations);

            Console.WriteLine("\n\rSTATIONS");
            foreach (var t in stations)
            {
                Console.WriteLine($"{t.ID} {t.StationName} {t.EndStation}");
            }
        }

        static void InitializeTracks()
        {
            string[] tmp = FileManager.ReadFile(m.TrainTrackPath);
            FileManager.SplitFile(tmp, tracks);

            Console.WriteLine("\n\rSTATIONS");
            foreach (var t in tracks)
            {
                Console.WriteLine($"{t.ID} {t.StartStation} {t.Distance} {t.EndStation}");
            }
        }

        public static void StartTrain()
        {
            double distance = tracks[0].Distance*1000;

            var startStn = tracks.Where(x => x.ID == 1).Select(x => x.StartStation).FirstOrDefault();
            Console.WriteLine("Start station " +  stations.Where(x => x.ID == startStn).Select(x=> x.StationName).FirstOrDefault());

            var endStn = tracks.Where(x => x.ID == 1).Select(x => x.EndStation).FirstOrDefault();
            Console.WriteLine("End station " + stations.Where(x => x.ID == endStn).Select(x => x.StationName).FirstOrDefault());

            while (true)
            {
                int speed = 500;
                
                double time = 0.5;
                
                Thread.Sleep(500);
                Console.WriteLine("Train is moving..");
                distance -= (speed * time);
                Console.WriteLine("The distance remaining is {0}",distance);
                
                if (distance <= 0)
                {
                    ShowTime();
        
                     break;
                }
            }

            Console.WriteLine("Destination reached"); 
        }

        static void ShowTime()
        {
            Console.WriteLine(clock.DisplayTime());
        }
    }
}
