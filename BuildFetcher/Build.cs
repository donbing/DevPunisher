using System;
using System.Runtime.Serialization;
using BuildXml;

namespace BuildFetcher
{
    [DataContract]
    public class BuildingBuild : Build {
        public BuildingBuild(int buildNumber, string developerName) 
            : base(buildNumber, developerName) { }
    }

    [DataContract]
    public class FailedBuild : Build {
        public FailedBuild(int buildNumber, string developerName) 
            : base(buildNumber, developerName) { }
    }

    [DataContract]
    public class SuccessfullBuild : Build {
        public SuccessfullBuild(int buildNumber, string developerName) 
            : base(buildNumber, developerName) { }
    }

    [DataContract]
    [KnownType(typeof(SuccessfullBuild))]
    [KnownType(typeof(BuildingBuild))]
    [KnownType(typeof(FailedBuild))]
    public abstract partial class Build
    {
        public Build(int buildNumber, string developerName)
        {
            Number = buildNumber;
            DeveloperName = developerName;
        }

        public int Number
        {
            get; set;
        }

        public string DeveloperName
        {
            get; set;
        }
    }
}