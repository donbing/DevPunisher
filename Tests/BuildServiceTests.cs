﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Xml.Linq;
using Build_Fetcher;
using Build_Service;
using Build_Fetcher.AutoGeneratedClasses;

namespace Build_Service.Tests
{
    [TestClass]
    public class When_Requesting_Current_Build_For_A_Job
    {
        BuildService buildService;
        const string JobName = "ruby";

        [TestInitialize]
        public void SetupDependancies()
        {
            var xmlFetcher = new HudsonXmlFetcher();
            var buildFetcher = new HudsonBuildFetcher(xmlFetcher);
            var jobFetcher = new HudsonJobFetcher(xmlFetcher);

            buildService = new BuildService(buildFetcher, jobFetcher);
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
