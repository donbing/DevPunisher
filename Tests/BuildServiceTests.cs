using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Xml.Linq;
using Build_Fetcher;
using Build_Service;

namespace Build_Service.Tests
{
    [TestClass]
    public class When_Requesting_Current_Build_For_A_Job
    {
        BuildService buildService;
        const string JobName = "ruby";
        const int LastBuildNumber = 2183;

        [TestInitialize]
        public void SetupDependancies()
        {
            var xmlFetcher = new HudsonXmlFetcher();
            var buildMapper = new BuildMapper();
            var jobMapper = new JobMapper();

            buildService = new BuildService(xmlFetcher, buildMapper, jobMapper);
        }

        [TestMethod]
        public void Should_Successfully_Retrieve_A_Build()
        {
            var currentBuild = buildService.GetCurrentBuild(JobName);

            Assert.IsNotNull(currentBuild);
            Assert.IsInstanceOfType(currentBuild, typeof(Build));
        }
    }
}
