using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Xml.Linq;
using BuildFetcher;
using BuildFetcherService;

namespace BuildFetcher.Tests
{
    [TestClass]
    public class WhenRequestingCurrentBuildForTrunkBuilder
    {
        HudsonBuildFetcher buildService;
        const string JobName = "TrunkBuilder";
        const int LastBuildNumber = 2183;

        [TestInitialize]
        public void SetupDependancies()
        {
            var xmlFetcher = MockTrunkBuilderXmlFetcher();
            var buildMapper = new BuildMapper();
            var jobMapper = new JobMapper();

            buildService = new HudsonBuildFetcher(xmlFetcher, buildMapper, jobMapper);
        }

        private static IHudsonXmlFetcher MockTrunkBuilderXmlFetcher()
        {
            var xmlFetcher = MockRepository.GenerateStrictMock<IHudsonXmlFetcher>();

            xmlFetcher.Stub(x => x.GetJobXmlFor(JobName))
                .Return(TestHelper.TrunkBuilderJobXml);
            
            xmlFetcher.Stub(x => x.GetBuildXmlFor(JobName, LastBuildNumber))
                .Return(TestHelper.SuccessfullBuildXml);

            return xmlFetcher;
        }

        [TestMethod]
        public void ShouldGetCurrentBuildState()
        {
            var currentBuild = buildService.GetCurrentBuild(JobName);

            Assert.IsInstanceOfType(currentBuild, typeof(SuccessfullBuild));

            Assert.IsNotNull(currentBuild.DeveloperName);
            Assert.IsNotNull(currentBuild.Number);
        }
    }
}
