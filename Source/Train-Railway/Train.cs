using System;
using System.Collections.Generic;

namespace Train_Railway
{
    public class Train
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Speed { get; set; }
        public int MaxSpeed { get; set; }
        public bool Operated { get; set; }
        public Train(int id, string name, int maxSpeed, bool operated)
        {
            this.ID = id;
            this.Name = name;
            this.MaxSpeed = maxSpeed;
            this.Operated = operated;
        }

        List<Passenger> wagon = new List<Passenger>();

        public void SetSpeed(int speed)
        {
            this.Speed = speed;
        }

        public void LoadPassengers(int amount, List<Passenger> loadPassengers)
        {

        }

        public void UnloadPassengers(int amount, List<Passenger> unloadPassengers)
        {

        }






    }
}