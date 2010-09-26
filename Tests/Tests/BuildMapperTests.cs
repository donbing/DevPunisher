using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml.Linq;
using BuildFetcher;
using System.Reflection;
using System.Xml;

namespace BuildFetcher.Tests
{
    [TestClass]
    public abstract class WithBuildMapper
    {
        protected Build currentBuild;
        protected string developerName;
        protected int buildNumber;

        protected Build ParseBuildReportXml(XDocument xmlFile)
        {
            return new BuildMapper().CreateBuildFrom(xmlFile);
        }

        [TestMethod]
        public void ShouldParseDevleoperName()
        {
            Assert.AreEqual(developerName, currentBuild.DeveloperName);
        }

        [TestMethod]
        public void ShouldParseBuildNumber()
        {
            Assert.AreEqual(buildNumber, currentBuild.Number);
        }
    }

    [TestClass]
    public class WhenBuildStartedAnonymously : WithBuildMapper
    {
        [TestInitialize]
        public void Setup()
        {
            buildNumber = 2184;
            developerName = "anonymous";
            currentBuild = ParseBuildReportXml(TestHelper.AnonymousBuildXml);
        }
    }

    [TestClass]
    public class WhenBuildIsPassing : WithBuildMapper
    {
        [TestInitialize]
        public void Setup()
        {
            buildNumber = 2180;
            developerName = "Chris";
            currentBuild = ParseBuildReportXml(TestHelper.SuccessfullBuildXml);
        }

        [TestMethod]
        public void ShouldReportSuccessfullBuild()
        {
            Assert.IsInstanceOfType(currentBuild, typeof(SuccessfullBuild));
        }
    }

    [TestClass]
    public class WhenBuildIsBuilding : WithBuildMapper
    {
        [TestInitialize]
        public void Setup()
        {
            buildNumber = 2183;
            developerName = "Alex";
            currentBuild = ParseBuildReportXml(TestHelper.BuildingBuildXml);
        }

        [TestMethod]
        public void ShouldReportBuildingBuild()
        {
            Assert.IsInstanceOfType(currentBuild, typeof(BuildingBuild));
        }
    }

    [TestClass]
    public class WhenBuildIsFailing : WithBuildMapper
    {
        [TestInitialize]
        public void Setup()
        {
            buildNumber = 2173;
            developerName = "jonny";
            currentBuild = ParseBuildReportXml(TestHelper.FailedBuildXml);
        }

        [TestMethod]
        public void ShouldReportFailedBuild()
        {
            Assert.IsInstanceOfType(currentBuild, typeof(FailedBuild));
        }
    }
}
