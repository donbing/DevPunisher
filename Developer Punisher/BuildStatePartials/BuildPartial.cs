using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Developer_Punisher.MissileLauncherService;

namespace Developer_Punisher.BuildService
{
    public abstract partial class Build
    {
        protected IMissileLauncherService missileLauncher;

        // TODO: is it possible to ctor inject the service?, maybe summat else?
        public Build With(IMissileLauncherService missileService) {
            this.missileLauncher = missileService;
            return this;
        }

        public void TransitionTo(Build updatedBuildState) {
            updatedBuildState.TakeActionFrom(this);
        }

        public abstract void TakeActionFrom(Build previousBuild);
        public abstract void ReportBuildFailed();
        public abstract void ReportBuildPassed();
        public abstract void ReportBuildBuilding();
    }

    public partial class FailedBuild
    {
        public override void TakeActionFrom(Build previousBuild) {
            previousBuild.ReportBuildFailed();
        }

        public override void ReportBuildFailed() {
        }

        public override void ReportBuildPassed() {
        }

        public override void ReportBuildBuilding() {
        }
    }

    public partial class BuildingBuild 
    {
        public override void TakeActionFrom(Build previousBuild) {
            previousBuild.ReportBuildBuilding();
        }

        public override void ReportBuildFailed() {
            this.missileLauncher.Execute(new FireCommand());
        }

        public override void ReportBuildPassed() {
        }

        public override void ReportBuildBuilding() {
        }
    }

    public partial class SuccessfullBuild 
    {
        public override void TakeActionFrom(Build previousBuild) {
            previousBuild.ReportBuildPassed();
        }

        public override void ReportBuildFailed() {
        }

        public override void ReportBuildPassed() {
        }

        public override void ReportBuildBuilding() {
        }
    }
}
