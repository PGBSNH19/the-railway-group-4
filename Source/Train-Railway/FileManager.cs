using System;
using System.IO;

namespace Train_Railway
{
    class FilesPath
    {
        public string PassengersPath = "Data/passengers.txt";
        public string TimetablePath = "Data/timetable.txt";
        public string ControllerPath = "Data/controllerlog.txt";
        public string SationPath = "Data/stations.txt";
        public string TrainPath = "Data/trains.txt";
        public string TrainTrackPath = "Data/traintrack.txt";
    }
    public class FileManager
    {
        public void ReadingFile(string filePath)
        {
            string[] data = File.ReadAllLines(filePath);
            char[] splitBy = { ',', ';' };

            for (int i = 0; i < data.Length; i++)
            {
                string[] splitedData = data[i].Split(splitBy);

                foreach (var item in splitedData)
                {
                    Console.WriteLine(item);
                }

            }
        }
    }
}