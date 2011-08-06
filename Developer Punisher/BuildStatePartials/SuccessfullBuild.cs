using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Developer_Punisher.MissileLauncherService;

namespace Developer_Punisher.BuildService
{
    public partial class SuccessfullBuild
    {
        public override Build TakeActionFrom(Build previousBuild)
        {
            previousBuild.With(missileLauncher).ReportBuildPassed();
            return this;
        }

        public override void ReportBuildFailed()
        {
            missileLauncher.Execute(new FireCommand());
        }

        public override void ReportBuildPassed()
        {
        }

        public override void ReportBuildBuilding()
        {
        }
    }
}
