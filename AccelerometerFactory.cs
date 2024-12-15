using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneSpeedyBlupi
{
    public class AccelerometerFactory
    {
        public static Accelerometer Create() { return new AccelerometerDummyImpl(); }
    }
}
