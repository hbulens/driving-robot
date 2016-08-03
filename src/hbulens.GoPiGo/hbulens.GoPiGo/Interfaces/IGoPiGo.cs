using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.GoPiGo
{
    public interface IGoPiGo
    {   
        byte DigitalRead(Pin pin);
        void DigitalWrite(Pin pin, byte value);      
        void AnalogWrite(Pin pin, byte value);
        void PinMode(Pin pin, PinMode mode);       
        IGoPiGo RunCommand(Commands command, byte firstParam = Constants.Unused, byte secondParam = Constants.Unused, byte thirdParam = Constants.Unused);
    }
}
