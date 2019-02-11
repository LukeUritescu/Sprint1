using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP2
{
    public class Engine
    {
        public bool IsStarted;

        public string About()
        {
            if (IsStarted)
                return "Engine is started";
            else
                return "Engine not started";
          
        }

        public Engine()
        {
            IsStarted = false;
        }

        public void Start()
        {
            IsStarted = true;
        }

        public void Stop()
        {
            IsStarted = false;
        }
    }
}
