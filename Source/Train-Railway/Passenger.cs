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

		static List<string> PassengerListOnBoard;
		static Random rand = new Random();
		public static void OnBoard(List<Passenger> passengers)
		{
			List<string> passengersOnBoard = new List<string>();
			for (int i = 0; i < 15; i++)
			{
				passengersOnBoard.Add(passengers[rand.Next(1, passengers.Count)].Name);
			}
			PassengerListOnBoard = passengersOnBoard.Distinct().ToList();
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine("Passengers List: ");
			Console.ResetColor();
			foreach (var item in PassengerListOnBoard)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine("\n");
		}
	}
}