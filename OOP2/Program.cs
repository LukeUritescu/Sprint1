using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Tester test = new Tester();
            test.Test();
            Console.ReadLine();
        }
    }

    class Tester
    {
        public void Test()
        {
            //Console.WriteLine("Flying Vehicle Tester");
            //Console.WriteLine("\nAirplane.cs");

            ////Airplane class tests
            //Airplane ap = new Airplane();
            ////Airport airport = new Airport("ABCD", 0);
            //Console.WriteLine(ap.About());

            //Console.WriteLine("\nAirplaneTakeOffTests.");
            //Console.WriteLine("\nCall ap.TakeOff():");
            ////This will fail
            //Console.WriteLine(ap.TakeOff());
            //Console.WriteLine("\nCall ap.StartEngine():");
            //ap.StartEngine();
            //Console.WriteLine(ap.TakeOff());

            ////Fly up
            //Console.WriteLine("\nFly up Tests");
            //Console.WriteLine("\n Call ap.FlyUp() fly to 1,000ft default");
            //ap.FlyUp();
            //Console.WriteLine(ap.About());
            //Console.WriteLine("\nCall ap.FlyUp(44000) Flly up to 45,000ft:");
            //ap.FlyUp(44000);
            //Console.WriteLine(ap.About());
            //Console.WriteLine("\nCall ap.FlyUp(40000) Fly up another 40,000ft");
            //ap.FlyUp(40000);
            //Console.WriteLine(ap.About());

            //Land
            //Console.WriteLine("\nFly Down");
            //Console.WriteLine("Call ap.FlyDown(50000) Fly Down 50,000ft");
            //ap.FlyDown(50000);
            //Console.WriteLine(ap.About());
            //Console.WriteLine("Call ap.FlyDown(ap.CurrentAltitude) this should land");
            //ap.FlyDown(ap.CurrentAltitude);
            //Console.WriteLine(ap.About());
            //Console.ReadLine();

            //Console.Clear();

            ///
            // Testing Airport
            ///
            
            //airport.AllTakeOff();
            //airport.Land(ap);
            //Console.WriteLine(airport.AllTakeOff());
            //Allow to see results for airplane then clear screen for toyplane testing
            //Console.ReadLine();
            //Console.Clear();

            ToyPlane toy = new ToyPlane();
            Console.WriteLine(toy.About());

            Console.WriteLine("\nToyplaneTakeOffTests.");
            Console.WriteLine("\nCall toy.TakeOff():");
            Console.WriteLine(toy.TakeOff());
            Console.WriteLine(toy.getEngineStartedString());
            Console.WriteLine(toy.GetWindUpString());

            //Wind up and start engine
            toy.WindUp();
            toy.StartEngine();
            toy.TakeOff();
            //Fly Up
            Console.WriteLine("\nFly Up Tests");
            toy.FlyUp(10);
            Console.WriteLine(toy.About());
            Console.WriteLine("\nCall FlyUp(60) which would be 70ft total");
            toy.FlyUp(60); //Shouldn't work;
            toy.FlyUp(40); //should reach max
            toy.FlyUp(10); //shouldn't work
            Console.WriteLine(toy.About());

            //Land
            Console.WriteLine("\nFly Down");
            Console.WriteLine("\nCall toy.FlyDown(60) fly down 60ft");
            toy.FlyDown(60); //Won't work
            Console.WriteLine("\nCall toy.FlyDown(currentAltitude) this should land");
            toy.FlyDown(toy.CurrentAltitude);
            Console.WriteLine(toy.About());


        }
    }
}
