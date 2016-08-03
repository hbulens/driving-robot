namespace hbulens.GoPiGo
{
    /// <summary>
    /// 
    /// </summary>
    public class EncoderService : IEncoderService
    {
        #region Constructor

        public EncoderService(GoPiGo goPiGo)
        {
            this.GoPiGo = goPiGo;
        }

        #endregion Constructor

        #region Properties

        private readonly GoPiGo GoPiGo;

        #endregion Properties

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="motorOneState"></param>
        /// <param name="motorTwoState"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        public IEncoderService SetEncoderTargetingOn(State motorOneState, State motorTwoState, int target)
        {
            var motorSelect = (int)motorOneState * 2 + (int)motorTwoState;
            this.GoPiGo.RunCommand(Commands.SetEncoderTargeting, (byte)motorSelect, (byte)(target / 256), (byte)(target % 256));
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="motor"></param>
        /// <returns></returns>
        public int ReadEncoder(Motor motor)
        {
            var buffer = new[] { (byte)Commands.ReadEncoder, (byte)motor, Constants.Unused, Constants.Unused };
            this.GoPiGo.DirectAccess.Write(buffer);
            this.GoPiGo.DirectAccess.Read(buffer);

            int encoder = buffer[1] * 256 + buffer[2];
            return encoder;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEncoderService EnableEncoders()
        {
            this.GoPiGo.RunCommand(Commands.EnableEncoder);
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IEncoderService DisableEncoders()
        {
            this.GoPiGo.RunCommand(Commands.DisableEncoder);
            return this;
        }

        #endregion Methods

    }
}
