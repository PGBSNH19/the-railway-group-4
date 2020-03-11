using System;
using System.Collections.Generic;
using System.IO;

namespace Train_Railway
{
    class FilesPath
    {
        public string PassengersPath = "Data/passengers.txt";
        public string TimetablePath = "Data/timetable.txt";
        public string ControllerPath = "Data/controllerlog.txt";
        public string StationPath = "Data/stations.txt";
        public string TrainPath = "Data/trains.txt";
        public string TrainTrackPath = "Data/traintrack.txt";
    }


    class FileManager
    {
        public static string[] ReadFile(string filePath)
        {
            string[] file = File.ReadAllLines(filePath);
            
            return file;
        }

        public static void SplitFile(string[] dataToSplit, List<Timetable> timetable)
        {
            for (int i = 1; i < dataToSplit.Length; i++)
            {
                string[] tmp = dataToSplit[i].Split(',');
                timetable.Add(new Timetable(tmp[3], tmp[2], tmp[0], int.Parse(tmp[1])));
            }
        }

        public static void SplitFile(string[] dataToSplit, List<Passenger> passenger)
        {
            for (int i = 1; i < dataToSplit.Length; i++)
            {
                string[] tmp = dataToSplit[i].Split(';');
                passenger.Add(new Passenger(int.Parse(tmp[0]), tmp[1]));
            }
        }

        public static void SplitFile(string[] dataToSplit, List<Train> train)
        {
            for (int i = 1; i < dataToSplit.Length; i++)
            {
                string[] tmp = dataToSplit[i].Split(',');
                train.Add(new Train(int.Parse(tmp[0]), tmp[1], int.Parse(tmp[2]), bool.Parse(tmp[3])));
            }
        }

        public static void SplitFile(string[] dataToSplit, List<Station> station)
        {
            for (int i = 1; i < dataToSplit.Length; i++)
            {
                string[] tmp = dataToSplit[i].Split('|');
                station.Add(new Station(int.Parse(tmp[0]), tmp[1], bool.Parse(tmp[2])));
            }
        }

        public static void SplitFile(string[] dataToSplit, List<Track> track)
        {
            for (int i = 1; i < dataToSplit.Length; i++)
            {
                string[] tmp = dataToSplit[i].Split(';');
                track.Add(new Track(int.Parse(tmp[0]), int.Parse(tmp[1]), double.Parse(tmp[2]), int.Parse(tmp[3])));
            }
        }
    }
}