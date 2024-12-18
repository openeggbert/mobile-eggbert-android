using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneSpeedyBlupi
{
    public class AccelerometerFactory
    {
        public static IAccelerometer Create() { return new AccelerometerDummyImpl(); }
    }
}
