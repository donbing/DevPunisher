using System;
namespace Missile_Launcher
{
    public interface IMissileDevice
    {
        void Command(DeviceCommand command);
    }
}
