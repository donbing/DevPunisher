using System.Xml.Linq;

namespace Build_Fetcher
{
    public interface IHudsonJobXmlFetcher
    {
        XDocument GetJobXmlFor(string jobName);
    }

    public interface IHudsonBuildXmlFetcher
    {
        XDocument GetBuildXmlFor(string jobName, int buildNumber);
    }

    public interface IHudsonXmlFetcher : IHudsonJobXmlFetcher, IHudsonBuildXmlFetcher
    { }


    public class HudsonXmlFetcher : IHudsonXmlFetcher
    {
        private readonly string rootUri;

        public HudsonXmlFetcher(string rootUri)
        {
            this.rootUri = rootUri;
        }

        public XDocument GetJobXmlFor(string jobName)
        {
            string jobUri = string.Format("{0}/job/{1}/api/xml", rootUri, jobName);

            return LoadXmlFrom(jobUri);
        }

        public XDocument GetBuildXmlFor(string jobName, int buildNumber)
        {
            string buildUri = string.Format("{0}/job/{1}/{2}/api/xml", rootUri, jobName, buildNumber);

            return LoadXmlFrom(buildUri);
        }

        private static XDocument LoadXmlFrom(string uri)
        {
            return XDocument.Load(uri);
        }
    }
}