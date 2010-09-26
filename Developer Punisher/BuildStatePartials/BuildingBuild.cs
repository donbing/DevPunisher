using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Developer_Punisher.BuildService
{
    public partial class BuildingBuild
    {
        public override void TakeActionFrom(Build previousBuild)
        {
            previousBuild.ReportBuildBuilding();
        }

        public override void ReportBuildFailed()
        {
            this.missileLauncher.Execute(new FireCommand());
        }

        public override void ReportBuildPassed()
        {
        }

        public override void ReportBuildBuilding()
        {
        }
    }
}
