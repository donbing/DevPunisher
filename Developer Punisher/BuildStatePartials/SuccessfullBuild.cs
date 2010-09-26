using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Developer_Punisher.BuildService
{
    public partial class SuccessfullBuild
    {
        public override void TakeActionFrom(Build previousBuild)
        {
            previousBuild.ReportBuildPassed();
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
