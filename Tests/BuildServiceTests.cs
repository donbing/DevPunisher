﻿using System;
using BuildFetcher;
using BuildFetcher.AutoGeneratedClasses;
using NUnit.Framework;
using System.Configuration;
using Service_Factory;
using StructureMap;

namespace Build_Service.Tests
{
    [TestFixture]
    public class When_Requesting_Current_Build_For_A_Job
    {
        BuildService buildService;
        const string JobName = "ruby";

        [SetUp]
        public void SetupDependancies()
        {
			var rootUri = ConfigurationManager.AppSettings["HudsonRootUri"];
            var buildxmlFetcher = new HudsonBuildXmlFetcher();
			
            var jobxmlFetcher = new HudsonJobXmlFetcher();
            var buildFetcher = new HudsonBuildFetcher(buildxmlFetcher);
            var jobFetcher = new HudsonJobFetcher(jobxmlFetcher);

            buildService = new BuildService(buildFetcher, jobFetcher);
        }

        [Test]
        public void Should_Successfully_Retrieve_A_Build()
        {
            var currentBuild = buildService.GetCurrentBuild(JobName);

            Assert.IsNotNull(currentBuild);
            Assert.IsInstanceOfType(typeof(Build), currentBuild);
        }
    }
	
	[TestFixture]
	public class SreaterService
	{
		[Test]
		public void foo()
		{
			var fac = new StructureMapServiceHostFactory();

            var x = fac.CreateServiceHost("BuildService", new[] { new Uri("http://localhost:8300/foo") });
		    
		}		
	}
}
