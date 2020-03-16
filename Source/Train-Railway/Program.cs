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

        //static FilesPath m = new FilesPath();
        static Clock clock = new Clock(10, 19);
        static void Main(string[] args)
        {
            IninitalizeData();
            List<Train> avaliableTrains = new List<Train>();
            var tmpTrains = trains.Where(t => t.Operated == true);
            foreach (Train train in tmpTrains)
            {
                avaliableTrains.Add(train);
            }

            //Train train1 = avaliableTrains[0];
            Train train2 = avaliableTrains[1];

            Thread track1 = new Thread(StartTrain1);
            //Thread track2 = new Thread(StartTrain2);
            track1.Start();
            //track2.Start();

            Time();
            //ShowTime();

            Console.ReadKey();
        }

        static async void Time()
        {
            while (true)
            {
                clock.Tick();
                //Console.WriteLine(clock.DisplayTime());
                await Task.Delay(1000);
                //Console.Clear();
            }
        }

        static void ShowTime()
        {
            Console.WriteLine(clock.DisplayTime());
        }

        static Train GetActiveTrain(int index)
        {
            List<Train> avaliableTrains = new List<Train>();
            var tmpTrains = trains.Where(t => t.Operated == true);
            foreach (Train train in tmpTrains)
            {
                avaliableTrains.Add(train);
            }
            return avaliableTrains[index];
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
            string[] tmp = FileManager.ReadFile(FilesPath.TimetablePath);
            FileManager.SplitFile(tmp, timeTables);

            Console.WriteLine("TIMETABLE");
            foreach (var t in timeTables)
            {
                Console.WriteLine($"{t.Arrival} {t.Departure} {t.StationID} {t.TrainID}");
            }
        }

        static void InitializePassengers()
        {
            string[] tmp = FileManager.ReadFile(FilesPath.PassengersPath);
            FileManager.SplitFile(tmp, passengers);

            Console.WriteLine("\n\rPASSENGERS");
            foreach (var t in passengers)
            {
                Console.WriteLine($"{t.ID} {t.Name}");
            }
        }

        static void InitializeTrains()
        {
            string[] tmp = FileManager.ReadFile(FilesPath.TrainPath);
            FileManager.SplitFile(tmp, trains);

            Console.WriteLine("\n\rTRAINS");
            foreach (var t in trains)
            {
                Console.WriteLine($"{t.ID} {t.Name} {t.MaxSpeed} {t.Operated}");
            }
        }

        static void InitializeStations()
        {
            string[] tmp = FileManager.ReadFile(FilesPath.StationPath);
            FileManager.SplitFile(tmp, stations);

            Console.WriteLine("\n\rSTATIONS");
            foreach (var t in stations)
            {
                Console.WriteLine($"{t.ID} {t.StationName} {t.EndStation}");
                t.IsAvaliable = true;
            }
        }

        static void InitializeTracks()
        {
            string[] tmp = FileManager.ReadFile(FilesPath.TrainTrackPath);
            FileManager.SplitFile(tmp, tracks);

            Console.WriteLine("\n\rSTATIONS");
            foreach (var t in tracks)
            {
                Console.WriteLine($"{t.ID} {t.StartStation} {t.Distance} {t.EndStation}");
            }
        }

        public static void StartTrain1()
        {
            var route = tracks.Where(t => t.ID == 1 || t.ID == 2);
            List<Track> trainTrack1 = new List<Track>();
            foreach (Track track in route)
            {
                trainTrack1.Add(track);
            }

            Train train1 = GetActiveTrain(0);
            for (int i = 0; i < trainTrack1.Count; i++)
            {
                Passenger.OnBoard(passengers);
                int speed = CommandCenter.CalculateStartSpeed(clock, timeTables, trainTrack1, i);
                train1.Speed = CommandCenter.Start(speed);

                int startStn = CommandCenter.DepartFromStation(route, trainTrack1, stations, clock, i);
                //var startStn = route.Where(x => x.ID == trainTrack1[i].ID).Select(x => x.StartStation).FirstOrDefault();
                //Console.Write("Train now depart from: " + stations.Where(x => x.ID == startStn).Select(x => x.StationName).FirstOrDefault());

                int endStn = CommandCenter.DepartToStation(route, trainTrack1, stations, clock, i);
                //var endStn = route.Where(x => x.ID == trainTrack1[i].ID).Select(x => x.EndStation).FirstOrDefault();
                //Console.Write(", End station: " + stations.Where(x => x.ID == endStn).Select(x => x.StationName).FirstOrDefault() + "\n\r");
                Console.WriteLine("Time of Depature: " + clock.DisplayTime());

                double distance = tracks[i].Distance * 1000;

                while (true)
                {
                    double calcDistancePerMin = (double)train1.Speed * 16.666666666;
                    int distancePerMin = (int)Math.Ceiling(calcDistancePerMin);

                    Thread.Sleep(1000);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("==>>");
                    Console.ResetColor();
                    distance -= (distancePerMin);
                    //Console.WriteLine("The distance remaining is {0}", distance);

                    if (distance <= 0)
                    {
                        Console.WriteLine("\n\rTrain arrived at station: " + stations.Where(x => x.ID == endStn).Select(x => x.StationName).FirstOrDefault());
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Passengers Geting Off...\n");
                        Console.ResetColor();
                        Thread.Sleep(3000);
                        for (int y = 0; y < stations.Count; y++)
                        {
                            if (stations[y].ID == endStn)
                            {
                                if (stations[y].IsAvaliable == true)
                                {
                                    /*static bool isInitialized;
                                    static object initLock = new object();

                                    static void InitializeIfNeeded()
                                    {
                                        if (!isInitialized)
                                        {
                                            lock (initLock)
                                            {
                                                if (!isInitialized)
                                                {
                                                    // init code here

                                                    isInitialized = true;
                                                }
                                            }
                                        }
                                    }*/
                                    stations[y].IsAvaliable = false;
                                    Console.WriteLine("Station is now avaliable: " + stations[y].IsAvaliable);
                                    Console.WriteLine("Time of arrival: " + clock.DisplayTime());
                                }

                                else
                                {
                                    Console.WriteLine(stations[y].StationName + " is currently occupied, plz wait");
                                    //train.wait
                                }
                            }
                        }

                        break;
                    }
                }
            }

            Console.WriteLine("Destination reached");
        }

        /*public static void StartTrain2()
        {
            var route = tracks;
            //double distance = tracks[0].Distance*1000;

            //var startStn = tracks.Where(x => x.ID == 1).Select(x => x.StartStation).FirstOrDefault();
            //Console.WriteLine("Start station " +  stations.Where(x => x.ID == startStn).Select(x=> x.StationName).FirstOrDefault());

            //var endStn = tracks.Where(x => x.ID == 1).Select(x => x.EndStation).FirstOrDefault();
            //Console.WriteLine("End station " + stations.Where(x => x.ID == endStn).Select(x => x.StationName).FirstOrDefault());

            for (int i = 0; i < route.Count; i++)
            {
                double distance = tracks[i].Distance * 1000;
                var startStn = route.Where(x => x.ID == route[i].ID).Select(x => x.StartStation).FirstOrDefault();
                Console.WriteLine("Train starting from: " + stations.Where(x => x.ID == startStn).Select(x => x.StationName).FirstOrDefault());

                var endStn = tracks.Where(x => x.ID == route[i].ID).Select(x => x.EndStation).FirstOrDefault();
                Console.WriteLine("End station " + stations.Where(x => x.ID == endStn).Select(x => x.StationName).FirstOrDefault());

                while (true)
                {
                    int speed = 500;

                    double time = 0.5;

                    Thread.Sleep(500);
                    Console.Write(".");
                    distance -= (speed * time);
                    //Console.WriteLine("The distance remaining is {0}", distance);

                    if (distance <= 0)
                    {
                        for (int y = 0; y < stations.Count; y++)
                        {
                            if (stations[y].ID == endStn)
                            {
                                stations[y].Occupied = true;
                                //Console.WriteLine(stations[y].Occupied + " is not occupied " );
                                if (stations[y].Occupied == false)
                                {
                                    stations[y].Occupied = true;
                                    Console.WriteLine(stations[y].Occupied + " is now occupied");
                                }

                                else
                                {
                                    Console.WriteLine(stations[y].StationName + " is currently occupied, plz wait");
                                    //train.wait
                                }
                            }
                        }

                        //Console.WriteLine("Index: " + stationIndex);
                        //Console.WriteLine("Index: " + index);
                        Console.WriteLine("\n\rTrain arrived at station: " + stations.Where(x => x.ID == endStn).Select(x => x.StationName).FirstOrDefault());
                        ShowTime();

                        break;
                    }
                }
            }

        }*/
    }
}
