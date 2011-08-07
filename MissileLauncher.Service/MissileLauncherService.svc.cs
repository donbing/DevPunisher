using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Missile_Launcher_Service
{
    [ServiceContract]
    public interface IMissileLauncherService
    {
        [OperationContract]
        void Execute(MissileLauncherCommand command);
    }

    public class MissileLauncherService : IMissileLauncherService
	{
		IMissileLauncher launcher;

        public MissileLauncherService(IMissileLauncher launcher)
        {
            this.launcher = launcher;
        }

        public void Execute(MissileLauncherCommand command)
        {
            command.ExecuteOn(launcher);
        }
	}
}
