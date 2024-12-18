using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Devices.Sensors;

namespace WindowsPhoneSpeedyBlupi
{
    public class AccelerometerAndroidImpl : IAccelerometer
    {
        public event EventHandler<AccelerometerEventArgs> CurrentValueChanged;

        private Accelerometer accelerometer = new Accelerometer();
        public void Start()
        {
            accelerometer.Start();
        }

        public void Stop()
        {
            accelerometer.Stop();
        }
    }
}
