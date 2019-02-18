using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{


    public class ToyPlane : Airplane
    { 
        
       
        public bool IsWoundUp;

        public string GetWindUpString()
        {
            if (IsWoundUp)
                return "ToyPlane is wound up";
            else
                return "ToyPlane not wound up";
        }

        public override void StartEngine()
        {
            if (IsWoundUp) {
                Engine.Start();
                Console.WriteLine(this + " is wound up. Engine started");
            }
            else
                Console.WriteLine(this + " is not wound up, engine can not be started.");
        }

        public ToyPlane() : base()
        {
            MaxAltitude = 50;
            IsFlying = false;
            IsWoundUp = false;
        }
        public void UnWind()
        {
            IsWoundUp = false;
        }
        public void WindUp()
        {
            IsWoundUp = true;
        }
    }
}
