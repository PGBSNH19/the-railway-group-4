﻿using System;
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
        static List<Track> tracks = new List<Track>();
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
    }
}
