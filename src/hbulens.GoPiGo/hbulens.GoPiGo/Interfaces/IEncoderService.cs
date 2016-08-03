using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.GoPiGo
{
    /// <summary>
    /// 
    /// </summary>
    public interface IEncoderService
    {
        IEncoderService SetEncoderTargetingOn(State motorOneState, State motorTwoStatem, int target);
        int ReadEncoder(Motor motor);
        IEncoderService EnableEncoders();
        IEncoderService DisableEncoders();
    }
}
