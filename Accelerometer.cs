using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneSpeedyBlupi
{
    public interface Accelerometer
    {
        void Start();
        void Stop();
        event EventHandler<AccelerometerEventArgs> CurrentValueChanged;
    }
}
