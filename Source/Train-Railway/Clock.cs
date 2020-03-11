using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train_Railway
{
    class Clock
    {
        public int Hour {get; set;}
        public int Minute { get; set; }
        
        public Clock(int h, int m)
        {
            this.Hour = h;
            this.Minute = m;
            
        }

        public void Tick()
        {
         
            this.Minute++;
            if (this.Minute == 60)
            {
                this.Hour++;
                this.Minute = 00;
            }

            if (this.Hour == 24)
            {
                this.Hour = 00;
            }
        }

        public string DisplayTime()
        {
            string time = this.Hour.ToString("D2") + ":" + this.Minute.ToString("D2");
            return time;

        }
    }
}
