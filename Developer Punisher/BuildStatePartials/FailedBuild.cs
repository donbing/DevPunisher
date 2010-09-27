using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Developer_Punisher.BuildService
{
    public partial class FailedBuild
    {
        public override Build TakeActionFrom(Build previousBuild)
        {
            previousBuild.ReportBuildFailed();
            return this;
        }

        public override void ReportBuildFailed()
        {
        }

        public override void ReportBuildPassed()
        {
        }

        public override void ReportBuildBuilding()
        {
        }
    }
}
