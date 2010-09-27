﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Build_Fetcher.AutoGeneratedClasses;
using System.Xml.Linq;

namespace Build_Fetcher.Tests
{
    [TestClass]
    public class WhenRetrievingLiveJobFromJobName
    {
        static Job job;
        const string JobName = "ruby";

        [ClassInitialize]
        public static void setup(TestContext ctx)
        {
            var xmlFetcher = new HudsonXmlFetcher();
            var jobFetcher = new HudsonJobFetcher(xmlFetcher);

            job = jobFetcher.GetJobFromJobName(JobName);
        }

        [TestMethod]
        public void ShouldHaveRequestedJobName()
        {
            Assert.AreEqual(JobName, job.Name);
        }

        [TestMethod]
        public void ShouldHaveABuildNumber()
        {
            Assert.IsTrue(job.NextBuildNumber > 0);
        }

        [TestMethod]
        public void ShouldHaveALastCompletedBuild()
        {
            Assert.IsTrue(job.LastCompletedBuild.number > 0);
            Assert.IsFalse(string.IsNullOrEmpty(job.LastCompletedBuild.url));
        }

        [TestMethod]
        public void ShouldHaveALastBuild()
        {
            Assert.IsTrue(job.LastBuild.number > 0);
            Assert.IsFalse(string.IsNullOrEmpty(job.LastBuild.url));
        }
    }

    
}
