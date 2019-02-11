using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public abstract class AerialVehicle
    {
        public int CurrentAltitude { get; set; }
        public Engine Engine { get; set; }
        public bool IsFlying {get;set;} 
        public int MaxAltitude { get; set; }

        public string About()
        {
            return this + " has a max altitude of " + MaxAltitude + " feet. \nIt's Current Altitude is: " + CurrentAltitude + " feet.\nThe " + getEngineStartedString();
        }
        public AerialVehicle()
        {
            this.CurrentAltitude = 0;
            this.IsFlying = false;
            Engine = new Engine();
        }

        public void FlyDown()
        {
            FlyDown(1000);
        }
        public void FlyDown(int HowManyFeet)
        {
            if (IsFlying)
            {
                Console.WriteLine("The desired amount of feet to descend: " + HowManyFeet + " feet");
                if ((CurrentAltitude - HowManyFeet) < 0)
                    Console.WriteLine("The desired feet to descend is not a viable number. Please choose a number less or equal to current altitude");
                else
                {
                    Console.WriteLine("The plane has descended " + HowManyFeet + " feet, and is now at " + (CurrentAltitude - HowManyFeet) + " feet");
                    CurrentAltitude = CurrentAltitude - HowManyFeet;
                }
            }
            else
                Console.WriteLine("vehicle is not flying.");
        }
        public void FlyUp()
        {
            FlyUp(1000);
        }
        public void FlyUp(int HowManyFeet)
        {
            if (IsFlying)
            {
                Console.WriteLine("The desired amount of feet to ascend: " + HowManyFeet + " feet");
                if ((HowManyFeet + CurrentAltitude) > MaxAltitude)
                    Console.WriteLine("The desired feet to ascend is not a viable number. Please choose a number that will not exceed " + MaxAltitude);
                else
                {
                    Console.WriteLine(this + " has ascended " + HowManyFeet + " feet, and is now at " + (CurrentAltitude + HowManyFeet) + " feet");
                    CurrentAltitude = CurrentAltitude + HowManyFeet;
                }
            }
            else
                Console.WriteLine("vehicle is not flying.");
        }
        public string getEngineStartedString()
        {
            if (Engine.IsStarted)
                return "Engine is started";
            else
                return "Engine not started";
        }
        public virtual void StartEngine()
        {
            Engine.Start();
        }
        public void StopEngine()
        {
            Engine.Stop();
        }
        public virtual string TakeOff()
        {
            if (Engine.IsStarted)
            {
                IsFlying = true;
                return "This engine has started";
            }
            else
            {
                return "This engine can't fly until the engine is started";
            }
        }
    }
}
