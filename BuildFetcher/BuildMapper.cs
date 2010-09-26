using System;
using System.Xml.Linq;
using System.Xml.Serialization;
using BuildXml;
using System.IO;

namespace BuildFetcher
{
    public interface IBuildMapper
    {
        Build CreateBuildFrom(XDocument buildXml);
    }

    public class BuildMapper : IBuildMapper
    {
        public Build CreateBuildFrom(XDocument buildXml)
        {
            var serializer = new XmlSerializer(typeof(freeStyleBuild));
            var reader = buildXml.CreateReader();
            var deserializedBuildData = (freeStyleBuild)serializer.Deserialize(reader);

            var currentBuild = HudsonBuildFactory.CreateBuildFrom(deserializedBuildData);

            return currentBuild;
        }
    }

    public class HudsonBuildFactory
    {
        const string SuccessResult = "SUCCESS";
        const string FailureResult = "FAILURE";

        public static Build CreateBuildFrom(freeStyleBuild hudsonBuildData)
        {
            var buildNumber = int.Parse(hudsonBuildData.number);
            var developerName = hudsonBuildData.culprit == null
                ? "anonymous"
                : hudsonBuildData.culprit[0].fullName;

            if (hudsonBuildData.result == SuccessResult)
                return new SuccessfullBuild(buildNumber, developerName);
            if (hudsonBuildData.building == "true")
                return new BuildingBuild(buildNumber, developerName);
            if (hudsonBuildData.result == FailureResult)
                return new FailedBuild(buildNumber, developerName);

            throw new ArgumentException("build status not wreckognised");
        }
    }
}