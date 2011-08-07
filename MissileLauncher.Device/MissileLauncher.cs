using System;
using System.Collections.Generic;
using System.Text;
using MissileCommandService;	
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
        { device.Execute(DeviceCommand.Left); }

        public void Right() 
        { device.Execute(DeviceCommand.Right); }

        public void Up() 
        { device.Execute(DeviceCommand.Up); }

        public void Down() 
        { device.Execute(DeviceCommand.Down);}

        public void Fire() 
        { device.Execute(DeviceCommand.Fire);}

        public void Stop() 
        { device.Execute(DeviceCommand.Stop); }
    }
}
