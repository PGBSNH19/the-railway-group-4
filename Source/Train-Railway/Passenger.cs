using System;

namespace Train_Railway
{
	public class Passenger
	{
		public int ID { get; set; }
		public string Name { get; set; }
		public bool Embark { get; set; }
		public bool Disembark { get; set; }

		public Passenger(int id, string name)
		{
			ID = id;
			Name = name;
		}

		public void TravelDestination()
		{

		}
	}
}