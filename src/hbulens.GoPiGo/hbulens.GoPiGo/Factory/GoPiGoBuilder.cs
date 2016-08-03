using hbulens.GoPiGo.Sensors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Devices.I2c;

namespace hbulens.GoPiGo
{
    internal class GoPiGoBuilder : IGoPiGoBuilder
    {
        #region Constructor

        internal GoPiGoBuilder()
        {

        }

        #endregion Constructor

        #region Properties

        private const string I2CName = "I2C1"; /* For Raspberry Pi 2, use I2C1 */
        private const byte GoPiGoAddress = 0x08;
        private GoPiGo _device;

        #endregion Properties

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public ILed BuildLed(Pin pin)
        {
            return DoBuild(x => new Led(x, pin));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public IUltrasonicRangerSensor BuildUltraSonicSensor(Pin pin)
        {
            return DoBuild(x => new UltrasonicRangerSensor(x, pin));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSensor"></typeparam>
        /// <param name="factory"></param>
        /// <returns></returns>
        private TSensor DoBuild<TSensor>(Func<GoPiGo, TSensor> factory)
        {
            var device = BuildGoPiGoImpl(GoPiGoAddress);
            return factory(device);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IGoPiGo Build()
        {
            return BuildGoPiGoImpl(GoPiGoAddress);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public IGoPiGo BuildGoPiGo(int address)
        {
            return BuildGoPiGoImpl(address);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goPiGoAddress"></param>
        /// <returns></returns>
        private GoPiGo BuildGoPiGoImpl(int goPiGoAddress)
        {
            if (_device != null)
            {
                return _device;
            }

            /* Initialize the I2C bus */
            var settings = new I2cConnectionSettings(goPiGoAddress)
            {
                BusSpeed = I2cBusSpeed.StandardMode
            };

            _device = Task.Run(async () =>
            {
                var dis = await GetDeviceInfo();

                // Create an I2cDevice with our selected bus controller and I2C settings
                var device = await I2cDevice.FromIdAsync(dis[0].Id, settings);
                return new GoPiGo(device);
            }).Result;
            return _device;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static async Task<DeviceInformationCollection> GetDeviceInfo()
        {
            //Find the selector string for the I2C bus controller
            var aqs = I2cDevice.GetDeviceSelector(I2CName);
            //Find the I2C bus controller device with our selector string
            var dis = await DeviceInformation.FindAllAsync(aqs);
            return dis;
        }

        #endregion Methods             
    }
}
