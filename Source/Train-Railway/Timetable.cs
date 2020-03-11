using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Railway
{
 
    class Timetable
    {
        public string Arrival { get; set; }
        public string Departure { get; set; }
        public string TrainID { get; set; }
        public int StationID { get; set; }

        public Timetable(string arrival, string departure, string trainID, int stationID)
        {
            this.Arrival = arrival;
            this.Departure = departure;
            this.TrainID = trainID;
            this.StationID = stationID;
        }
    }
}
