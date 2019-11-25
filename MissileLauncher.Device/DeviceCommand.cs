using System;

namespace Missile_Launcher
{
    [Flags]
    public enum DeviceCommand
    {
        Up,
        Down,
        Left,
        Right,
        Fire,
        Stop
    }
}