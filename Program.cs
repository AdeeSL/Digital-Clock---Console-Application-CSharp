using System;

namespace Clock
{

    class Clock
    {
        public int hours;
        public int minutes;
        public int seconds;
        public string countryName; 
        public int tempMin; 
        public int tempHour; 

        public Clock(string countryName , double time)
        {
            DateTime now = DateTime.UtcNow; 
            this.seconds = now.Second;
            tempMin = now.Minute + (int)(((float)time - (int)time) * 100);
            if (tempMin < 60)
            {
                this.minutes = tempMin;
                tempHou = now.Hour + (int)time;
            }
            else
            {
                this.minutes = tempMin - 60;
                tempHou = now.Hour + (int)time + (tempMin / 60);
            }

            if (tempHou < 24)
            {
                if (tempHou < 0)
                {
                    this.hours = tempHou + 24;
                }
                this.hours = tempHou;
            }
            else
            {
                this.hours = tempHou - 24;
            }
            this.countryName = countryName;

        }

        public void printClock()
        {
            this.tick();
            Console.WriteLine("  {0}   {1:D2}:{2:D2}:{3:D2}",this.countryName,this.hours,this.minutes,this.seconds);

        }

        public void tick()
        {
            if (this.seconds < 59)
            {
                incrementSeconds();
            }
            else
            {
                this.seconds = 0;
                if (this.minutes < 59)
                {
                    incrementMinutes();
                }
                else
                {
                    this.minutes = 0;
                    incrementHours();
                }
            }
        }

        private void incrementSeconds()
        {
            this.seconds += 1;
        }

        private void incrementMinutes()
        {
            this.minutes += 1;
        }

        private void incrementHours()
        {
            if (this.hours < 24)
            {
                this.hours += 1;
            }
            else
            {
                this.hours = 0;
            }
        }
    }
    class ClockTester
    {
        static void Main(string[] args)
        {
            Clock sl = new Clock("Sri Lanka, Sri Jayawardenepura", +05.30);
            Clock ch = new Clock("China", +08.00);
            //can add more

            while(true)
            {
                Console.Clear();

                Console.WriteLine("  {0}   {1}", "Country", "Time\n");

                ch.printClock();
                sl.printClock();

                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
