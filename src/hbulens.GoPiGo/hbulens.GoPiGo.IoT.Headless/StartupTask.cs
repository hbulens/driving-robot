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

        public StartupTask()
        {

        }

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
            restRouteHandler.RegisterController<MotorApiController>();

            // Register Web API on the 8800 port
            HttpServer httpServer = new HttpServer(8800);

            // Register the API route
            httpServer.RegisterRoute("api", restRouteHandler);

            // Start the host
            httpServer.StartServerAsync().Wait();

            // This will prevent the background instance from shutting down immediately
            _deferral = taskInstance.GetDeferral();

        }

        #endregion Methods

    }
}
