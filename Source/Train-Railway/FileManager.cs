using System;
using System.Collections.Generic;
using System.IO;

namespace Train_Railway
{
    public interface IData { }

    class FilesPath
    {
        public string PassengersPath = "Data/passengers.txt";
        public string TimetablePath = "Data/timetable.txt";
        public string ControllerPath = "Data/controllerlog.txt";
        public string SationPath = "Data/stations.txt";
        public string TrainPath = "Data/trains.txt";
        public string TrainTrackPath = "Data/traintrack.txt";
    }

    public interface IFilesRead
    {
        string[] ReadingFile(string filePath);
    }

    /*public interface IFilesSplit
    {
        void SplitFile(IData idata);
    }*/

    class FileManager: IFilesRead //,IFilesSplit
    {
        //private string[] data;

        public FileManager()
        {

        }

        public string[] ReadingFile(string filePath)
        {
            string[] data = File.ReadAllLines(filePath);
            
            return data;
        }

        /*public void SplitFile<T>(List<T> theList)
        {
            char[] splitBy = { ',', ';' };

            for (int i = 0; i < data.Length; i++)
            {
                string[] splitedData = data[i].Split(splitBy);

                theList.Add(new )

            }
        }*/
    }
}