using System;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;
using hbulens.GoPiGo.Sensors;

namespace hbulens.GoPiGo
{
    public static class GoPiGoFactory
    {
        public static IGoPiGoBuilder Build = new GoPiGoBuilder();
    }     
}
