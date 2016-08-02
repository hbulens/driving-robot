using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using Windows.ApplicationModel.Background;
using Devkoes.Restup.WebServer.Rest;
using Devkoes.Restup.WebServer.Http;

namespace hbulens.GoPiGo.IoT.Headless
{
    /// <summary>
    /// 
    /// </summary>
    public sealed class StartupTask : IBackgroundTask
    {
        #region Constructor

        #endregion Constructor

        #region Members

        private BackgroundTaskDeferral _deferral;

        #endregion Members

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="taskInstance"></param>
        public void Run(IBackgroundTaskInstance taskInstance)
        {
            // Register API
            RestRouteHandler restRouteHandler = new RestRouteHandler();
            restRouteHandler.RegisterController<MotorController>();

            // Start Web API Host
            HttpServer httpServer = new HttpServer(8800);
            httpServer.RegisterRoute("api", restRouteHandler);
            httpServer.StartServerAsync().Wait();

            _deferral = taskInstance.GetDeferral();

        }

        #endregion Methods

    }
}
