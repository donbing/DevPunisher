using System;
using System.Collections.Generic;
using System.Text;
using Missile_Launcher_Interface;

namespace Missile_Launcher
{
    public class MissileLauncher : IMissileLauncher
    {
        private MissileDevice device;

        public MissileLauncher(MissileDevice device)
        {
            this.device = device;
        }

        public void Left() 
        { device.Command(DeviceCommand.Left); }

        public void Right() 
        { device.Command(DeviceCommand.Right); }

        public void Up() 
        { device.Command(DeviceCommand.Up); }

        public void Down() 
        { device.Command(DeviceCommand.Down);}

        public void Fire() 
        { device.Command(DeviceCommand.Fire);}

        public void Stop() 
        { device.Command(DeviceCommand.Stop); }
    }
}
