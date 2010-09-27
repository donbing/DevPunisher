using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Developer_Punisher.MissileLauncherService;
using Developer_Punisher.BuildService;

namespace Developer_Punisher
{
    public class DevPunisher
    {
        IMissileLauncherService missileService;
        IBuildFetcherService buildService;
        Build currentBuildState;

        public DevPunisher(IMissileLauncherService missileService, IBuildFetcherService buildService)
        {
            this.buildService = buildService;
            this.missileService = missileService;

            currentBuildState = GetCurrentBuild();
        }

        public void BringThePain()
        {
            var updatedBuildState = GetCurrentBuild();
            var buildContext = new BuildContext(currentBuildState, missileService);

            currentBuildState = buildContext.UpdateTo(updatedBuildState);
        }

        private Build GetCurrentBuild()
        {
            return buildService.GetCurrentBuild("TrunkBuilder");
        }
    }

    public class BuildContext
    {
        Build origionalBuild;
        IMissileLauncherService missileService;

        public BuildContext(Build origionalBuild,IMissileLauncherService missileService)
        {
            this.origionalBuild = origionalBuild;
            this.missileService = missileService;
        }

        public Build UpdateTo(Build newBuild)
        {
            return newBuild
                .With(missileService)
                .TakeActionFrom(origionalBuild);
        }
    }
}
