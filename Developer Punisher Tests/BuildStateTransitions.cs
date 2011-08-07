using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Rhino.Mocks;
using Developer_Punisher.MissileLauncherService;
using Developer_Punisher.BuildService;
using Developer_Punisher;
using NUnit.Framework;

namespace Developer_Punisher_Tests
{
    public abstract class WithDevPunisher
    {
        protected IMissileLauncherService missileService;
        private IBuildFetcherService buildService;
        private DevPunisher punisher;
        private List<Build> buildUpdateOrder; 

        [SetUp]
        public void SetupPunisherAndBuildStates()
        {
            MockTheServices();

            StubTheBuildServiceCalls();
            
            RunSomeBuildChecks();
        }

        private void RunSomeBuildChecks()
        {
            punisher = new DevPunisher(missileService, buildService);

            // first call is the initial state, so we dont make an update check for it
            for (int i = 0; i < buildUpdateOrder.Skip(1).Count(); i++)
            {
                punisher.BringThePain();
            }
        }

        private void StubTheBuildServiceCalls()
        {
            buildUpdateOrder = GetListOfBuildUpdates().ToList();

            buildUpdateOrder.ForEach(build =>
               buildService.Stub(svc => svc.GetCurrentBuild("TrunkBuilder")).Return(build).Repeat.Once()
            );
        }

        private void MockTheServices()
        {
            missileService = MockRepository.GenerateMock<IMissileLauncherService>();
            buildService = MockRepository.GenerateMock<IBuildFetcherService>();
        }

        protected abstract IEnumerable<Build> GetListOfBuildUpdates();
    }

    [TestFixture]
    public class WhenBuildChangesFromBuildingToFailing : WithDevPunisher
    {
        [Test]
        public void ShouldFireRocketLauncher()
        {
            missileService.AssertWasCalled(svc => svc.Execute(Arg<FireCommand>.Is.Anything));
        }

        protected override IEnumerable<Build> GetListOfBuildUpdates()
        {
            yield return new BuildingBuild();
            yield return new FailedBuild();
        }
    }

    [TestFixture]
    public class WhenBuildChangesFromBuildingToPassing : WithDevPunisher
    {
        [Test]
        public void ShouldNotFireRocketLauncher()
        {
            missileService.AssertWasNotCalled(svc => svc.Execute(Arg<MissileLauncherCommand>.Is.Anything));
        }

        protected override IEnumerable<Build> GetListOfBuildUpdates()
        {
            yield return new BuildingBuild();
            yield return new SuccessfullBuild();
        }
    }

    [TestFixture]
    public class WhenBuildUpdatesFromBuildingToBuilding : WithDevPunisher
    {
        [Test]
        public void ShouldNotFireRocketLauncher()
        {
            missileService.AssertWasNotCalled(svc => svc.Execute(Arg<MissileLauncherCommand>.Is.Anything));
        }

        protected override IEnumerable<Build> GetListOfBuildUpdates()
        {
            yield return new BuildingBuild();
            yield return new BuildingBuild();
        }
    }

    [TestFixture]
    public class WhenBuildUpdatesFromFailingToFailing : WithDevPunisher
    {
        [Test]
        public void ShouldNotFireRocketLauncher()
        {
            missileService.AssertWasNotCalled(svc => svc.Execute(Arg<MissileLauncherCommand>.Is.Anything));
        }

        protected override IEnumerable<Build> GetListOfBuildUpdates()
        {
            yield return new FailedBuild();
            yield return new FailedBuild();
        }
    }

    [TestFixture]
    public class WhenBuildUpdatesFromFailingToBuildingToFailing : WithDevPunisher
    {
        [Test]
        public void ShouldNotFireRocketLauncher()
        {
            missileService.AssertWasNotCalled(svc => svc.Execute(Arg<MissileLauncherCommand>.Is.Anything));
        }

        protected override IEnumerable<Build> GetListOfBuildUpdates()
        {
            yield return new FailedBuild();
            yield return new BuildingBuild();
            yield return new FailedBuild();
        }
    }

    [TestFixture]
    public class WhenBuildGoes_Building_Passing_Building_Failing : WithDevPunisher
    {
        [Test]
        public void ShouldFireRocketLauncher()
        {
            missileService.AssertWasCalled(svc => svc.Execute(Arg<FireCommand>.Is.Anything));
        }

        protected override IEnumerable<Build> GetListOfBuildUpdates()
        {
            yield return new BuildingBuild();
            yield return new SuccessfullBuild();
            yield return new BuildingBuild();
            yield return new FailedBuild();
        }
    }

    [TestFixture]
    public class WhenBuildGoes_Failing_Building_Passing_Building_Failing : WithDevPunisher
    {
        [Test]
        public void ShouldFireRocketLauncher()
        {
            missileService.AssertWasCalled(svc => svc.Execute(Arg<FireCommand>.Is.Anything));
        }

        protected override IEnumerable<Build> GetListOfBuildUpdates()
        {
            yield return new FailedBuild();
            yield return new BuildingBuild();
            yield return new SuccessfullBuild();
            yield return new BuildingBuild();
            yield return new FailedBuild();
        }
    }
}
