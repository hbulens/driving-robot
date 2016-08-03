using System;

namespace hbulens.GoPiGo
{
    public class MotorService : IMotorService
    {
        #region Constructor

        public MotorService(IGoPiGo goPiGo)
        {
            if (goPiGo == null)
                throw new ArgumentNullException(nameof(goPiGo));

            this._goPiGo = goPiGo;
        }

        #endregion Constructor        

        #region Properties

        private readonly IGoPiGo _goPiGo;

        #endregion Properties

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMotorService MoveForward()
        {
            this._goPiGo.RunCommand(Commands.MoveForward);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMotorService MoveBackward()
        {
            this._goPiGo.RunCommand(Commands.MoveBackward);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMotorService MoveLeft()
        {
            this._goPiGo.RunCommand(Commands.MoveLeft);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMotorService RotateLeft()
        {
            this._goPiGo.RunCommand(Commands.RotateLeft);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMotorService MoveRight()
        {
            this._goPiGo.RunCommand(Commands.MoveRight);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMotorService RotateRight()
        {
            this._goPiGo.RunCommand(Commands.RotateRight);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMotorService Stop()
        {
            this._goPiGo.RunCommand(Commands.Stop);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMotorService IncreaseSpeed(int speed)
        {
            this._goPiGo.RunCommand(Commands.IncreaseSpeedBy10);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IMotorService DecreaseSpeed(int speed)
        {
            this._goPiGo.RunCommand(Commands.DecreaseSpeedBy10);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public IMotorService ControlMotorOne(int direction, int speed)
        {
            this._goPiGo.RunCommand(Commands.MotorOne, (byte)direction, (byte)speed);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        public IMotorService ControlMotorTwo(int direction, int speed)
        {
            this._goPiGo.RunCommand(Commands.MotorTwo, (byte)direction, (byte)speed);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public IMotorService SetLeftMotorSpeed(int speed)
        {
            speed = Math.Min(speed, 255);
            this._goPiGo.RunCommand(Commands.SetLeftMotorSpeed, (byte)speed);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public IMotorService SetRightMotorSpeed(int speed)
        {
            speed = Math.Min(speed, 255);
            this._goPiGo.RunCommand(Commands.SetRightMotorSpeed, (byte)speed);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="speed"></param>
        /// <returns></returns>
        public IMotorService SetSpeed(int speed)
        {
            SetLeftMotorSpeed(speed);
            SetRightMotorSpeed(speed);
            return this;
        }

        #endregion Methods        
    }
}
