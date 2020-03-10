using System;

namespace Train_Railway
{
	public class Passenger
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public string HopOn { get; set; }
		public string HopOff { get; set; }

		public Passenger(int id, string name)
		{
			ID = id;
			Name = name;
		}
	}
}