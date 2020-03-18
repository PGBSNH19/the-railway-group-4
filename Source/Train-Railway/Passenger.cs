using System;
using System.Collections.Generic;
using System.Linq;

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

		
		public static void OnBoard(List<Passenger> passengers)
		{
			List<string> PassengerListOnBoard;
		    Random rand = new Random();
			List<string> passengersOnBoard = new List<string>();
			for (int i = 0; i < 15; i++)
			{
				passengersOnBoard.Add(passengers[rand.Next(1, passengers.Count)].Name);
			}
			PassengerListOnBoard = passengersOnBoard.Distinct().ToList();
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine($"\n\rPassengers List: ");
			Console.ResetColor();
			foreach (var item in PassengerListOnBoard)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\n");
		}
	}
}