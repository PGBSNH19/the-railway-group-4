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
        ITrainInfo GetTrain(string[] data);
    }
    class Timetable : ITrainInfo
    {
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string TrainID { get; set; }
        public int StationID { get; set; }
        public ITrainInfo GetTrain(string[] data )
        {
            //foreach (var item in data)
            //{
            //    Console.WriteLine(item);
            //}
            List<string> file = new List<string>();
            file.Add(data[0]);


            this.TrainID = file[0];
            return this;
        }

        public string MyMethod()
        {
            Console.WriteLine(TrainID);
            return this.TrainID;
        }
    }
}


//public string TimetablePath = "Data/timetable.txt";
//public string MyMethod()
//{
//    string[] data = File.ReadAllLines(TimetablePath);
//    GetTrain(data);
//    return this.TrainID;
//}

//for (int i = 0; i < data.Length; i++)
//{
//    string[] splitedData = data[i].Split(',');

//    this.TrainID = splitedData[0];
//    Console.WriteLine("This Train ID is " + TrainID);
//}