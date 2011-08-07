using System.ServiceModel;

namespace MissileCommandService
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
