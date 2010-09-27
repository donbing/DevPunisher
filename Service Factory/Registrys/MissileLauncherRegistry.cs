using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using StructureMap.Configuration.DSL;
using Missile_Launcher;
using Missile_Launcher_Interface;

namespace Service_Factory.Registrys
{
    class MissileLauncherRegistry : Registry
    {
        public MissileLauncherRegistry()
        {
            For<MissileDevice>().Use<MissileDevice>();
            For<IMissileLauncher>().Use<MissileLauncher>();
        }
    }
}
