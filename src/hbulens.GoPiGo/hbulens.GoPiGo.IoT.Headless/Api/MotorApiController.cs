using Devkoes.Restup.WebServer.Attributes;
using Devkoes.Restup.WebServer.Models.Schemas;
using Devkoes.Restup.WebServer.Rest.Models.Contracts;
using hbulens.GoPiGo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.GoPiGo.IoT.Headless
{
    [RestController(InstanceCreationType.Singleton)]
    public sealed class MotorApiController
    {
        #region Constructor

        public MotorApiController()
        {
            this.MotorService = new MotorService(GoPiGoFactory.Build.Build());
        }

        #endregion Constructor

        #region Properties

        private IMotorService MotorService { get; set; }

        #endregion Properties

        #region Methods

        /// <summary>
        /// Moves the GoPiGo 5 seconds in the forward direction
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        [UriFormat("/Motors/MoveForward/{seconds}")]
        public IGetResponse MoveForward(int seconds)
        {
            // Run command, sleep for the specified amount of seconds and stop
            this.MotorService.MoveForward();
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
            this.MotorService.Stop();

            return new GetResponse(GetResponse.ResponseStatus.OK);
        }

        /// <summary>
        /// Moves the GoPiGo 5 seconds in the backward direction
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        [UriFormat("/Motors/MoveBackward/{seconds}")]
        public IGetResponse MoveBackward(int seconds)
        {
            // Run command, sleep for the specified amount of seconds and stop
            this.MotorService.MoveBackward();
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
            this.MotorService.Stop();

            return new GetResponse(GetResponse.ResponseStatus.OK);
        }

        /// <summary>
        /// Moves the GoPiGo 5 seconds to the left
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        [UriFormat("/Motors/MoveLeft/{seconds}")]
        public IGetResponse MoveLeft(int seconds)
        {
            // Run command, sleep for the specified amount of seconds and stop
            this.MotorService.MoveLeft();
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
            this.MotorService.Stop();

            return new GetResponse(GetResponse.ResponseStatus.OK);
        }

        /// <summary>
        /// Moves the GoPiGo 5 seconds to the right
        /// </summary>
        /// <param name="seconds"></param>
        /// <returns></returns>
        [UriFormat("/Motors/MoveRight/{seconds}")]
        public IGetResponse MoveRight(int seconds)
        {
            // Run command, sleep for the specified amount of seconds and stop
            this.MotorService.MoveRight();
            Task.Delay(TimeSpan.FromSeconds(seconds)).Wait();
            this.MotorService.Stop();

            return new GetResponse(GetResponse.ResponseStatus.OK);
        }

        #endregion Methods       
    }
}
