using System.Xml.Linq;

namespace Build_Fetcher
{
    public interface IJobMapper
    {
        Job CreateJobFrom(XDocument document);
    }

    public class JobMapper : IJobMapper
    {
        public Job CreateJobFrom(XDocument document)
        {
            var lastBuild = document.Element("freeStyleProject")
                .Element("lastBuild")
                .Element("number")
                .Value;

            return new Job { LastBuildNumber = int.Parse(lastBuild) };
        }
    }
}