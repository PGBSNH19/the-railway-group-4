using System.Collections.Generic;

namespace Train_Railway
{
    class Station
    {
        public int ID { get; set; }
        public string StationName { get; set; }
        public bool EndStation { get; set; }
        public bool IsAvaliable { get; set; } = false;

        public List<Passenger> Travelers = new List<Passenger>();

        public Station(int id, string stationName, bool endStation)
        {
            this.ID = id;
            this.StationName = stationName;
            this.EndStation = endStation;
        }
    }
}
