using System;
using Windows.Devices.I2c;

namespace hbulens.GoPiGo
{
    /// <summary>
    /// Main class to controll to GoPiGo
    /// </summary>
    public class GoPiGo : IGoPiGo
    {
        #region Constructor

        internal GoPiGo(I2cDevice device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            this.DirectAccess = device;
        }

        #endregion Constructor

        #region Properties

        internal I2cDevice DirectAccess { get; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public byte DigitalRead(Pin pin)
        {
            byte[] buffer = new[] { (byte)Commands.DigitalRead, (byte)pin, Constants.Unused, Constants.Unused };
            this.DirectAccess.Write(buffer);

            byte[] readBuffer = new byte[1];
            this.DirectAccess.Read(readBuffer);

            return readBuffer[0];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="value"></param>
        public void DigitalWrite(Pin pin, byte value)
        {
            byte[] buffer = new[]
            {
                (byte)Commands.DigitalWrite, (byte)pin, value, Constants.Unused
            };

            this.DirectAccess.Write(buffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pin"></param>
        /// <returns></returns>
        public int AnalogRead(Pin pin)
        {
            var buffer = new[]
            {
                (byte) Commands.DigitalRead,
                (byte) Commands.AnalogRead,
                (byte) pin, Constants.Unused,
                Constants.Unused
            };

            this.DirectAccess.Write(buffer);
            this.DirectAccess.Read(buffer);

            return buffer[1] * 256 + buffer[2];
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="value"></param>
        public void AnalogWrite(Pin pin, byte value)
        {
            byte[] buffer = new[] { (byte)Commands.AnalogWrite, (byte)pin, value, Constants.Unused };
            this.DirectAccess.Write(buffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pin"></param>
        /// <param name="mode"></param>
        public void PinMode(Pin pin, PinMode mode)
        {
            byte[] buffer = new[]
            {
                (byte)Commands.PinMode,
                (byte)pin,
                (byte)mode,
                Constants.Unused
            };

            this.DirectAccess.Write(buffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <param name="firstParam"></param>
        /// <param name="secondParam"></param>
        /// <param name="thirdParam"></param>
        /// <returns></returns>
        public IGoPiGo RunCommand(Commands command, byte firstParam = Constants.Unused, byte secondParam = Constants.Unused, byte thirdParam = Constants.Unused)
        {
            byte[] buffer = new[]
            {
                (byte)command,
                firstParam,
                secondParam,
                thirdParam
            };

            this.DirectAccess.Write(buffer);
            return this;
        }

        #endregion Methods

    }
}
