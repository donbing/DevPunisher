﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Developer_Punisher.MissileLauncherService;

namespace Developer_Punisher.BuildService
{
    public abstract partial class Build
    {
        protected Build LastKnownState;

        protected IMissileLauncherService missileLauncher;

        // TODO: find better way to do this :(
        public Build With(IMissileLauncherService missileService) {
            this.missileLauncher = missileService;
            return this;
        }

        public abstract Build TakeActionFrom(Build previousBuild);
        public abstract void ReportBuildFailed();
        public abstract void ReportBuildPassed();
        public abstract void ReportBuildBuilding();
    }
}
