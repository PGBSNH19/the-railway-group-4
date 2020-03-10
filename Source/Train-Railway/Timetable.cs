using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Railway
{
    class Timetable
    {
        public int Arrival { get; set; }
        public int Departure{ get; set; }
        public int TrainID { get; set; }
        public int StationID { get; set; }

        public void GetTrain(int arrival, int departure, int trainID, int stationID)
        {
            this.Arrival = arrival;
            this.Departure = departure;
            this.TrainID = trainID;
            this.StationID = stationID;
        }
    }
}
