using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class Airport
    {
        protected int MaxVehicles;
        public List<AerialVehicle> Vehicles = new List<AerialVehicle>();

        public string AirportCode { get; protected set; }

        public Airport(string Code)
        {
            this.AirportCode = Code;
        }

        public Airport(string Code, int maxVehicles)
        {
            this.AirportCode = Code;
            MaxVehicles = maxVehicles;
        }

        public string AllTakeOff()
        {
            if (Vehicles.Count != 0) //To make sure nothing takes off
            {
                for (int i = 0; i < Vehicles.Count; i++)
                {
                    TakeOff(Vehicles[i]);
                }
                return "Vehicle has taken off";

            }
            else
                return "There are no vehicles to take off";


        }

        public string Land(AerialVehicle a)
        {
            if (Vehicles.Count < MaxVehicles)
            {
                Vehicles.Add(a);
                a.FlyDown(a.CurrentAltitude);
                a.IsFlying = false;
                return this + " has landed.";
            }
            else
                return "The vehicle is not at 0 altitude yet.";
        }

        public string Land(List<AerialVehicle> landing)
        {
            foreach (AerialVehicle e in landing)
            {
                Land(e);
            }
            return "Vehicle is landing";
        }

        public string TakeOff(AerialVehicle a)
        {
            if (Vehicles != null)
            {

                Vehicles.Remove(a);
                return "This vehicle took off";
            }
            else
                return "There are no vehicles to take off";
        }
    }
}
