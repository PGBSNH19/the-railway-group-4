using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Railway
{
    interface ITrainInfo
    {
        //int Arrival { get; set; }
        //int Departure { get; set; }
        //int TrainID { get; set; }
        //int StationID { get; set; }
        ITrainInfo GetTrain(/*int arrival, int departure, int trainID, int stationID*/);
    }
    class Timetable: ITrainInfo
    {
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string TrainID { get; set; }
        public int StationID { get; set; }
       // public string TimetablePath = "Data/timetable.txt";
        public ITrainInfo GetTrain(/*int arrival, int departure, int trainID, int stationID*/)
        {
            //string[] data = File.ReadAllLines(TimetablePath);
            //for (int i = 0; i < data.Length; i++)
            //{
            //   string [] splitedData= data[i].Split(',');
            //    //Console.WriteLine(splitedData[0]);
            //    this.TrainID = splitedData[0];
            //    Console.WriteLine(TrainID);
            //    //foreach (var item in splitedData)
            //    //{
            //    //    //.WriteLine(item);
            //    //    this.TrainID = item[0];
            //    //    //this.StationID = item[1];
            //    //    //this.Departure = item[2].ToString();
            //    //    //this.Arrival = item[3].ToString();
            //    //}

            //}
            ////this.Arrival = arrival;
            //this.Departure = departure;
            //this.TrainID = trainID;
            //this.StationID = stationID;
            return this; 
        }
    }
}
