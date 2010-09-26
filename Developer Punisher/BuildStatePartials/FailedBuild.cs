using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Developer_Punisher.BuildService
{
    public partial class FailedBuild
    {
        public override void TakeActionFrom(Build previousBuild)
        {
            previousBuild.ReportBuildFailed();
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
