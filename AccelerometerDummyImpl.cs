﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsPhoneSpeedyBlupi
{
    public class AccelerometerDummyImpl : IAccelerometer
    {
        public event EventHandler<AccelerometerEventArgs> CurrentValueChanged;

        public void Start()
        {
            //throw new AccelerometerFailedException();
        }

        public void Stop()
        {
            //throw new AccelerometerFailedException();
        }
    }
}
