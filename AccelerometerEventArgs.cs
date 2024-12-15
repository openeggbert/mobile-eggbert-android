using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneSpeedyBlupi
{
    public class AccelerometerEventArgs : EventArgs
    {

        public float X { get; }
        public float Y { get; }
        public float Z { get; }

        public AccelerometerEventArgs(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }
    }
}
