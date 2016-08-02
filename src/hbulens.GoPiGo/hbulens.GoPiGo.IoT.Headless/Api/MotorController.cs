using Devkoes.Restup.WebServer.Attributes;
using Devkoes.Restup.WebServer.Models.Schemas;
using Devkoes.Restup.WebServer.Rest.Models.Contracts;
using GoPiGo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.GoPiGo.IoT.Headless
{
    [RestController(InstanceCreationType.Singleton)]
    public sealed class MotorController
    {
        [UriFormat("/Motors/{action}")]
        public IGetResponse GetWithSimpleParameters(string action)
        {
            IGoPiGo goPigo = DeviceFactory.Build.BuildGoPiGo();
            Task.Run(async () =>
            {
                goPigo.RunCommand(Commands.MoveForward);
                await Task.Delay(TimeSpan.FromSeconds(10));
            })
            .ContinueWith((x) =>
            {
                goPigo.RunCommand(Commands.Stop);
            });

            return new GetResponse(GetResponse.ResponseStatus.OK, new DataReceived()
            {
                Action = action
            });
        }
    }
}
