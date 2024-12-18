using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneSpeedyBlupi
{
    public interface IAccelerometer
    {
        void Start();
        void Stop();
        event EventHandler<AccelerometerEventArgs> CurrentValueChanged;
    }
}
