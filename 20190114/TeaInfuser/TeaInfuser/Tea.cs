using System;
using System.Collections.Generic;
using System.Text;

namespace TeaInfuser
{
    public class Tea
    {
        public Tea(TeaType type,int temperature, int time)
        {
            Type = type;
            TemperatureOfCooking = temperature;
            TimeOfCooking = time;
        }
        public TeaType Type { get; set; }
        public int TemperatureOfCooking { get; set; }
        public int TimeOfCooking { get; set; }

    }
}
