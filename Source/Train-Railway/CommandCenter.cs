using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Railway
{
    class CommandCenter
    {
        public static List<string> dataLogger = new List<string>();
        private static string aArrival;
        private static string stationName;
        private static string aDeparture;
        public static int Start(int speed)
        {
            return speed;
        }

        public static void Start(Train train, string time)
        {

        }

        public static void Stop(Train train)
        {
            train.Speed = 0;
        }

        public static int CalculateStartSpeed(Clock clock, List<Timetable> timetables, List<Track> tracks, int index)
        {
            aDeparture = clock.DisplayTime();
            int tmpIndex1 = aDeparture.IndexOf(':');
            string tmpTime1 = aDeparture.Substring(tmpIndex1 + 1, 2);
            if (tmpTime1[0] == '0')
            {
                tmpTime1.Remove(0);
            }
            int aDepTime = int.Parse(tmpTime1);

            string arrivalAtNextDes = timetables[index + 1].Arrival;
            int tmpIndex2 = arrivalAtNextDes.IndexOf(':');
            string tmpTime2 = arrivalAtNextDes.Substring(tmpIndex2 + 1, 2);
            if (tmpTime2[0] == '0')
            {
                tmpTime2.Remove(0);
            }
            int sArrTime = int.Parse(tmpTime2);

            int minutes = sArrTime - aDepTime;
            double result = ((double)minutes / 60);

            return (int)Math.Ceiling(tracks[index].Distance / result);
        }

        public static void ArriveAtStation(Train train, Clock clock, Station station, Timetable timetable)
        {
            //train.Speed = 0;
            aArrival = clock.DisplayTime();
            stationName = station.StationName;
            station.IsAvaliable = true;
        }

        public static int DepartFromStation(IEnumerable<Track> route, List<Track> track, List<Station> stations, Clock clock, int index)
        {
            var startStn = route.Where(x => x.ID == track[index].ID).Select(x => x.StartStation).FirstOrDefault();
            Console.Write("Train now depart from: " + stations.Where(x => x.ID == startStn).Select(x => x.StationName).FirstOrDefault());


            //aDeparture = clock.DisplayTime();

            //lås upp tråd
            return startStn;
        }

        public static int DepartToStation(IEnumerable<Track> route, List<Track> track, List<Station> stations, Clock clock, int index)
        {
            var endStn = route.Where(x => x.ID == track[index].ID).Select(x => x.EndStation).FirstOrDefault();
            Console.Write(", End station: " + stations.Where(x => x.ID == endStn).Select(x => x.StationName).FirstOrDefault() + "\n\r");

            
            return endStn;


        }

        public static int GetStartStationID(IEnumerable<Track> route, List<Track> track, List<Station> stations, int index)
        {
            var station = route.Where(x => x.ID == track[index].ID).Select(x => x.StartStation).FirstOrDefault();

            return station;
        }

        public static int GetEndStationID(IEnumerable<Track> route, List<Track> track, List<Station> stations, int index)
        {
            var station = route.Where(x => x.ID == track[index].ID).Select(x => x.EndStation).FirstOrDefault();

            return station;
        }

        public static void UnlockStation(int index, List<Station> stations)
        {
            stations[index].IsAvaliable = true;
            Console.WriteLine("Station is now avaliable: " + stations[index].IsAvaliable);
        }

        public static void LoadPassengers()
        {

        }

        public static void WriteLog(string filepath)
        {
            FileManager.WriteFile(filepath, dataLogger);
        }

        public static void LogData(string stationName, Clock clock)
        {
            string entry = $"{stationName},{aArrival},TimeTableArrival,{aDeparture}, TimeTableDeparture";
            dataLogger.Add(entry);
            stationName = "";
            aArrival = "";
            //TimeTableArriva ="";
            aDeparture = "";
            //TimeTableDeparture
        }

    }
}
