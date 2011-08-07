using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace MissileCommandService
{
    [DataContract]
    [KnownType(typeof(UpCommand))]
    [KnownType(typeof(LeftCommand))]
    [KnownType(typeof(DownCommand))]
    [KnownType(typeof(RightCommand))]
    [KnownType(typeof(StopCommand))]
    [KnownType(typeof(FireCommand))]
    public abstract class MissileLauncherCommand
    {
        public abstract void ExecuteOn(IMissileLauncher launcher);
    }

    public class UpCommand : MissileLauncherCommand
    {
        public override void ExecuteOn(IMissileLauncher launcher)
        {
            launcher.Up();
        }
    }

    public class LeftCommand : MissileLauncherCommand
    {
        public override void ExecuteOn(IMissileLauncher launcher)
        {
            launcher.Left();
        }
    }

    public class DownCommand : MissileLauncherCommand
    {
        public override void ExecuteOn(IMissileLauncher launcher)
        {
            launcher.Down();
        }
    }

    public class RightCommand : MissileLauncherCommand
    {
        public override void ExecuteOn(IMissileLauncher launcher)
        {
            launcher.Right();
        }
    }

    public class StopCommand : MissileLauncherCommand
    {
        public override void ExecuteOn(IMissileLauncher launcher)
        {
            launcher.Stop();
        }
    }

    public class FireCommand : MissileLauncherCommand
    {
        public override void ExecuteOn(IMissileLauncher launcher)
        {
            launcher.Fire();
        }
    }
}
