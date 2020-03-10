using System;
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






    }
}