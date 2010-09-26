using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using Missile_Launcher;
using LittleNet.UsbMissile;
using Missile_Launcher_Interface;

namespace Service_Factory.Registrys
{
    class MissileLauncherRegistry : Registry
    {
        public MissileLauncherRegistry()
        {
            For<IMissileLauncher>().Use<MissileLauncher>();
            For<IMissileDevice>().Use<MissileDevice>();
        }
    }
}
