using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Developer_Punisher.BuildService;

namespace Developer_Punisher.Tests
{
    [TestClass]
    public class WhenJobChangesFromBuildingToFailing
    {
        [TestMethod]
        public void TestMethod1()
        {
            INotifyBuildEvents eventNotifier;

            IBuildFetcherService svc = MockRepository.GenerateMock<IBuildFetcherService>();
        }
    }

    interface INotifyBuildEvents 
    {
        void SomeOneBrokeTheBuild();
        void SomeOneFixedTheBuild();
        void BuildIsStillBuilding();
    }
}
