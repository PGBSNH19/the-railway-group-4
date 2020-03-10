using System.Collections.Generic;

namespace Train_Railway
{
    class Station
    {
        public int ID { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }
        public bool Occupied { get; set; } = false;
        //private int id;

        public List<Passenger> Travelers = new List<Passenger>();

        public Station(int id, string stationName, bool endStation)
        {
            this.ID = id;
            this.StationName = stationName;
            this.EndStation = endStation;
        }

        public void InUse(bool b)
        {
            Occupied = b;
        }
    }
}
