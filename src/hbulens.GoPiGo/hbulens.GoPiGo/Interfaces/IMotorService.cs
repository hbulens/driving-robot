using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hbulens.GoPiGo
{
    public interface IMotorService
    {
        IMotorService MoveForward();
        IMotorService MoveBackward();
        IMotorService MoveLeft();
        IMotorService RotateLeft();
        IMotorService MoveRight();
        IMotorService RotateRight();
        IMotorService Stop();
        IMotorService IncreaseSpeed(int speed);
        IMotorService DecreaseSpeed(int speed);        
        IMotorService SetLeftMotorSpeed(int speed);
        IMotorService SetRightMotorSpeed(int speed);
    }
}
