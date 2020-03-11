using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Railway
{
    class Track
    {
        public int ID { get; set; }
        public int StartStation { get; set; }
        public double Distance { get; set; }
        public int EndStation { get; set; }

        public Track(int id, int startStn, double distance, int endStn)
        {
            this.ID = id;
            this.StartStation = startStn;
            this.Distance = distance;
            this.EndStation = endStn;
        }
    }
}
